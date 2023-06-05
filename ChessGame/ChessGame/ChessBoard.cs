using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChessGame.Taslar;

namespace ChessGame
{
    public class ChessBoard : Form
    {
        public readonly GameManager GameManager;

        private int tileSize = 60;
        private const int ROWS = 8;
        private const int COLUMNS = 8;
        private Button[,] buttons = new Button[ROWS, COLUMNS];
        private Label[] columnLabels = new Label[COLUMNS];
        private Label[] rowLabels = new Label[ROWS];
        private Panel panel1 = new Panel();
        private InputHandler _inputHandler;
        private List<ChessPiece> pieces = new List<ChessPiece>();

        public ChessBoard()
        {
            _inputHandler = new InputHandler(this);

            SetupLabels();
            SetupChessPieces();
            GameManager = new GameManager();
            GameManager.GetCurrentPlayer();
            SetupChessBoard();
            InitializeComponent();
        }

        private void SetupChessBoard()
        {
            panel1.Size = new Size(tileSize * 10, tileSize * 10);
            panel1.Location = new Point((panel1.Width - this.Width) / 2, (panel1.Height - this.Height) / 2);
            this.Controls.Add(panel1);
        }

        private void SetupChessPieces()
        {
            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(tileSize, tileSize);
                    button.BackColor = (i + j) % 2 == 0 ? System.Drawing.Color.Black : System.Drawing.Color.White;
                    panel1.Controls.Add(button);
                    button.Location = new Point(j * tileSize, i * tileSize);
                    button.Tag = new Tuple<int, int>(i, j);
                    buttons[i, j] = button;

                    // Taşların yerleştirilmesi
                    ChessPiece piece = null;
                    if (i == 0 || i == 7)
                    {
                        if (j == 0 || j == 7)
                            pieces.Add(piece = new Kale(i == 0 ? PieceColor.Black : PieceColor.White,
                                ChessPieceType.Kale, i, j, button));
                        else if (j == 1 || j == 6)
                            pieces.Add(piece = new At(i == 0 ? PieceColor.Black : PieceColor.White,
                                ChessPieceType.At, i, j, button));
                        else if (j == 2 || j == 5)
                            pieces.Add(piece = new Fil(i == 0 ? PieceColor.Black : PieceColor.White,
                                ChessPieceType.Fil, i, j, button));
                        else if (j == 3)
                            pieces.Add(piece = new Vezir(i == 0 ? PieceColor.Black : PieceColor.White,
                                ChessPieceType.Vezir, i, j, button));
                        else if (j == 4)
                            pieces.Add(piece = new Kral(i == 0 ? PieceColor.Black : PieceColor.White,
                                ChessPieceType.Kral, i, j, button));

                        if (piece != null)
                        {
                            button.BackgroundImage = piece.Image;
                            button.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    else if (i == 1 || i == 6)
                    {
                        pieces.Add(piece = new Piyon(i == 1 ? PieceColor.Black : PieceColor.White,
                            ChessPieceType.Piyon, i, j, button));
                        button.BackgroundImage = piece.Image;
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        private void SetupLabels()
        {
            for (int i = 0; i < COLUMNS; i++)
            {
                columnLabels[i] = new Label();
                columnLabels[i].Text = ((char)(65 + i)).ToString();
                columnLabels[i].Size = new Size(20, 20);
                columnLabels[i].Location = new Point((i * tileSize) + tileSize + 100, 100);
                columnLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                columnLabels[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(columnLabels[i]);
            }

            for (int i = 0; i < ROWS; i++)
            {
                rowLabels[i] = new Label();
                rowLabels[i].Text = (ROWS - i).ToString();
                rowLabels[i].Size = new Size(20, 20);
                rowLabels[i].Location = new Point(100, (i * tileSize) + tileSize + 100);
                rowLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                rowLabels[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(rowLabels[i]);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            foreach (var button in buttons)
            {
                button.Click += new EventHandler(_inputHandler.Tile_Click);
            }

            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Name = "ChessBoard";
            this.ResumeLayout(false);

        }

        public void UpdateBoard()
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button button)
                {
                    Tuple<int, int> position = (Tuple<int, int>)button.Tag;
                    ChessPiece piece = GetPieceAtPosition(position.Item1, position.Item2);

                    if (piece != null)
                    {
                        button.BackgroundImage = piece.Image;
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        button.BackgroundImage = null;
                    }

                    button.BackColor =
                        (position.Item1 + position.Item2) % 2 == 0
                            ? Color.Black
                            : Color.White; // siyah ve beyaz karelerin arka plan rengi
                }
            }
        }

        public ChessPiece GetPieceAtPosition(int row, int col)
        {
            foreach (ChessPiece piece in pieces)
            {
                if (piece.CurrentRow == row && piece.CurrentColumn == col)
                {
                    return piece;
                }
            }

            return null;
        }

        public void MovePiece(int fromRow, int fromCol, int toRow, int toCol)
        {
            // Başlangıç pozisyonundaki taşın alınması
            ChessPiece movingPiece = GetPieceAtPosition(fromRow, fromCol);
            if (movingPiece == null)
            {
                // Başlangıç pozisyonunda taş yoksa hata mesajı yazdırıp metodun sonlandırılması
                Console.WriteLine("Error: No piece found at starting position.");
                return;
            }

            // Taşın hedef pozisyona taşınması
            if (movingPiece.CanMove(toRow, toCol, this))
            {
                // Hedef pozisyonda taş yoksa taşın yerleştirilmesi
                ChessPiece targetPiece = GetPieceAtPosition(toRow, toCol);
                if (targetPiece == null)
                {
                    movingPiece.CurrentRow = toRow;
                    movingPiece.CurrentColumn = toCol;
                }
                // Hedef pozisyonda taş varsa taşın alınması ve yerine hareket eden taşın yerleştirilmesi
                else
                {
                    movingPiece.CurrentRow = toRow;
                    movingPiece.CurrentColumn = toCol;
                    pieces.Remove(targetPiece);
                }
            }
            else
            {
                // Hedef pozisyon geçersizse hata mesajı yazdırılır.
                Console.WriteLine("Error: Invalid move.");
                return;
            }
        }

        public bool IsOccupied(int row, int column)
        {
            if (row < 0 || row >= ROWS || column < 0 || column >= COLUMNS)
            {
                // Geçersiz koordinatlar
                return false;
            }

            foreach (var piece in pieces)
            {
                if (piece.CurrentColumn == column && piece.CurrentRow == row)
                {
                    return true;
                }
            }

            return false;
        }

        public Tuple<int, int> FindKingPosition(PieceColor kingColor)
        {
            foreach (ChessPiece piece in pieces)
            {
                if (piece.Type == ChessPieceType.Kral && piece.Color == kingColor)
                {
                    return Tuple.Create(piece.CurrentRow, piece.CurrentColumn);
                }
            }

            // Hedef renkteki kral bulunamazsa (-1, -1) dön
            return Tuple.Create(-1, -1);
        }

        public bool IsKingInCheck(PieceColor kingColor, ChessBoard board)
        {
            // Hedef kralın pozisyonunu bulma
            Tuple<int, int> kingPosition = board.FindKingPosition(kingColor);

            // Tüm rakip taşları kontrol etme
            foreach (ChessPiece piece in pieces)
            {
                if (piece.Color != kingColor)
                {
                    // Eğer rakip taş, hedef krala saldırabiliyorsa true döndür
                    if (piece.CanMove(kingPosition.Item1, kingPosition.Item2, board))
                    {
                        var king = GetPieceAtPosition(kingPosition.Item1, kingPosition.Item2);
                        king.Button.BackColor = Color.Red;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveInCheck(ChessPiece chessPiece, PieceColor color, ChessBoard board, int row, int col)
        {
            if (chessPiece != null && chessPiece.Color == color)
            {
                Tuple<int, int> originalPiecePos = new Tuple<int, int>(chessPiece.CurrentRow, chessPiece.CurrentColumn);

                if (chessPiece.CanMove(row, col, board))
                {
                    // Sah bu hamle ile tehdit altında olmayacak mı kontrol etme
                    // Hamleyi geçici olarak yapma
                    board.MovePiece(chessPiece.CurrentRow, chessPiece.CurrentColumn, row, col);
                    
                    // Sah tehdit altında mı kontrol etme
                    bool isKingSafe = !IsKingInCheck(color, board);
                    
                    // Hamleyi geri alma
                    board.MovePiece(chessPiece.CurrentRow, chessPiece.CurrentColumn, originalPiecePos.Item1,
                        originalPiecePos.Item2);

                    if ( GetPieceAtPosition(row, col)!= null)
                    {
                        var removedPiece = GetPieceAtPosition(row, col);
                        pieces.Remove(GetPieceAtPosition(row, col)); 
                        isKingSafe = !IsKingInCheck(color, board);
                        pieces.Add(removedPiece);
                    }

                    if (isKingSafe)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
