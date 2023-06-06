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
        private Label playerInfoLabel;
        private ImageList beyazTaslar;
        private System.ComponentModel.IContainer components;
        private ImageList siyahTaslar;
        private ListView beyazTaslarListesi;
        private ListView listView1;
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
            SignUpEvents();
            UpdatePlayerInfo();
        }

        private void SignUpEvents()
        {
            this.SuspendLayout();
            foreach (var button in buttons)
            {
                button.Click += new EventHandler(_inputHandler.HandleInput);
                button.MouseDown += _inputHandler.ShowProperties;
            }

            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Name = "ChessBoard";
            this.Text = "Chess Game";
            this.ResumeLayout(false);
            this.PerformLayout();
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
                            //button.Tag = (ChessPiece)piece;
                            button.BackgroundImage = piece.Image;
                            button.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    else if (i == 1 || i == 6)
                    {
                        pieces.Add(piece = new Piyon(i == 1 ? PieceColor.Black : PieceColor.White,
                            ChessPieceType.Piyon, i, j, button));
                        //button.Tag = (ChessPiece)piece;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessBoard));
            this.playerInfoLabel = new System.Windows.Forms.Label();
            this.beyazTaslar = new System.Windows.Forms.ImageList(this.components);
            this.siyahTaslar = new System.Windows.Forms.ImageList(this.components);
            this.beyazTaslarListesi = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // playerInfoLabel
            // 
            this.playerInfoLabel.AutoSize = true;
            this.playerInfoLabel.Location = new System.Drawing.Point(350, 50);
            this.playerInfoLabel.Name = "playerInfoLabel";
            this.playerInfoLabel.Size = new System.Drawing.Size(72, 13);
            this.playerInfoLabel.TabIndex = 0;
            this.playerInfoLabel.Text = "Oyuncu Sirasi";
            this.playerInfoLabel.Click += new System.EventHandler(this.playerInfoLabel_Click);
            // 
            // beyazTaslar
            // 
            this.beyazTaslar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("beyazTaslar.ImageStream")));
            this.beyazTaslar.TransparentColor = System.Drawing.Color.White;
            this.beyazTaslar.Images.SetKeyName(0, "Black_At.png");
            this.beyazTaslar.Images.SetKeyName(1, "Black_Fil.png");
            this.beyazTaslar.Images.SetKeyName(2, "White_Fil.png");
            // 
            // siyahTaslar
            // 
            this.siyahTaslar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.siyahTaslar.ImageSize = new System.Drawing.Size(16, 16);
            this.siyahTaslar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // beyazTaslarListesi
            // 
            this.beyazTaslarListesi.HideSelection = false;
            this.beyazTaslarListesi.LargeImageList = this.beyazTaslar;
            this.beyazTaslarListesi.Location = new System.Drawing.Point(12, 183);
            this.beyazTaslarListesi.Name = "beyazTaslarListesi";
            this.beyazTaslarListesi.Size = new System.Drawing.Size(76, 132);
            this.beyazTaslarListesi.TabIndex = 1;
            this.beyazTaslarListesi.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.beyazTaslar;
            this.listView1.Location = new System.Drawing.Point(12, 359);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(76, 132);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ChessBoard
            // 
            this.ClientSize = new System.Drawing.Size(1125, 623);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.beyazTaslarListesi);
            this.Controls.Add(this.playerInfoLabel);
            this.Name = "ChessBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

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
                    pieces.Remove(targetPiece);

                    movingPiece.CurrentRow = toRow;
                    movingPiece.CurrentColumn = toCol;
                }
            }
            else
            {
                // Hedef pozisyon geçersizse hata mesajı yazdırılır.
                Console.WriteLine("Error: Invalid move.");
                return;
            }
        }
        public void UndoMove(int fromRow, int fromCol, int toRow, int toCol, ChessPiece capturedPiece)
        {
            ChessPiece movingPiece = GetPieceAtPosition(toRow, toCol);
            if (movingPiece == null)
            {
                // Taş yoksa hata mesajı yazdırıp metodun sonlandırılması
                Console.WriteLine("Error: No piece found at target position.");
                return;
            }

            // Taşı başlangıç pozisyonuna yerleştirme
            movingPiece.CurrentRow = fromRow;
            movingPiece.CurrentColumn = fromCol;

            // Eğer yakalanan bir taş varsa, onu yerine geri yerleştirme
            if (capturedPiece != null)
            {
                pieces.Add(capturedPiece);
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

        public bool IsKingInCheck(PieceColor kingColor)
        {
            // Hedef kralın pozisyonunu bulma
            Tuple<int, int> kingPosition = FindKingPosition(kingColor);

            // Tüm rakip taşları kontrol etme
            foreach (ChessPiece piece in pieces)
            {
                if (piece.Color != kingColor)
                {
                    // Eğer rakip taş, hedef krala saldırabiliyorsa true döndür
                    if (piece.CanMove(kingPosition.Item1, kingPosition.Item2,this))
                    {
                        var king = GetPieceAtPosition(kingPosition.Item1, kingPosition.Item2);
                        king.Button.BackColor = Color.Red;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveInCheck(ChessPiece chessPiece, ChessBoard board, int row, int col)
        {
            if (chessPiece != null)
            {
                // Taşın mevcut konumu ve durumu
                int originalRow = chessPiece.CurrentRow;
                int originalCol = chessPiece.CurrentColumn;

                // Hedef konumda bir taş varsa al
                ChessPiece targetPiece = board.GetPieceAtPosition(row, col);

                // Hedef konuma taşı yerleştir
                board.MovePiece(originalRow, originalCol, row, col);

                // Sah tehdit altında mı kontrol et
                bool isKingSafe = !IsKingInCheck(chessPiece.Color);

                // Hedef konumda bir taş varsa tekrar yerleştir
                if (targetPiece == null)
                {
                    board.UndoMove(originalRow, originalCol,chessPiece.CurrentRow, chessPiece.CurrentColumn,null);
                }
                else
                {
                    board.UndoMove(originalRow, originalCol,chessPiece.CurrentRow, chessPiece.CurrentColumn,targetPiece);
                }

                return isKingSafe;
            }

            return false;
        }
        
        public bool IsCheckmate(PieceColor kingColor)
        {
            // Şah durumunda mat kontrolü yapmak için önce şah durumunu kontrol et
            if (!IsKingInCheck(kingColor))
            {
                // Şah durumu yoksa mat durumu da yoktur
                return false;
            }

            // Kralın mevcut pozisyonunu bulma
            Tuple<int, int> kingPosition = FindKingPosition(kingColor);
            ChessPiece king = GetPieceAtPosition(kingPosition.Item1, kingPosition.Item2);

            // Kralın tüm hamlelerini deneme
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Geçerli bir konum mu?
                    if (king.CanMove(row, col, this))
                    {
                        // Hamleyi geçici olarak yap
                        MovePiece(kingPosition.Item1, kingPosition.Item2, row, col);

                        // Kral hala şah altında mı?
                        if (!IsKingInCheck(kingColor))
                        {
                            // Hamleyi geri al
                            UndoMove(kingPosition.Item1, kingPosition.Item2, row, col, null);
                            return false;
                        }

                        // Hamleyi geri al
                        UndoMove(kingPosition.Item1, kingPosition.Item2, row, col, null);
                    }
                }
            }

            if (CanAnyPieceMoveInCheck(kingColor,this))
            {
                return false;
            }

            // Kralın tüm hamlelerini denedik, ancak hala şah altında ise mat durumu vardır
            return true;
        }
        
        public List<ChessPiece> GetPiecesByColor(PieceColor color)
        {
            List<ChessPiece> pieces = new List<ChessPiece>();

            foreach (ChessPiece piece in this.pieces)
            {
                if (piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }

            return pieces;
        }
        
        public bool CanAnyPieceMoveInCheck(PieceColor color, ChessBoard board)
        {
            // Renkteki tüm taşları al
            List<ChessPiece> pieces = board.GetPiecesByColor(color);

            // Her bir taş için hareketleri kontrol et
            foreach (ChessPiece piece in pieces)
            {
                // Taşın mevcut konumu ve durumu
                int originalRow = piece.CurrentRow;
                int originalCol = piece.CurrentColumn;

                // Tüm olası hareketleri deneme
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        // Geçerli bir konum mu?
                        if (piece.CanMove(row, col, board))
                        {
                            // Hedef konumda bir taş varsa al
                            ChessPiece targetPiece = board.GetPieceAtPosition(row, col);

                            // Hedef konuma taşı yerleştir
                            board.MovePiece(originalRow, originalCol, row, col);

                            // Sah tehdit altında mı kontrol et
                            bool isKingSafe = !IsKingInCheck(color);

                            // Hedef konumda bir taş varsa tekrar yerleştir
                            if (targetPiece == null)
                            {
                                board.UndoMove(originalRow, originalCol, row, col, null);
                            }
                            else
                            {
                                board.UndoMove(originalRow, originalCol, row, col, targetPiece);
                            }

                            // Eğer kral güvende ise, taş mat durumundan kurtarabiliyor
                            if (isKingSafe)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            // Hiçbir taş mat durumundan kurtaramıyor
            return false;
        }

        public void UpdatePlayerInfo()
        {
            playerInfoLabel.Text = "Oyuncu Sirasi : "+ GameManager.GetCurrentPlayerName();
        }

        public void UpdateWhiteDeathPiece(Image beyazTasResmi)
        {
            Image capturedPieceImage = beyazTasResmi;
            beyazTaslar.Images.Add(capturedPieceImage);

            ListViewItem capturedPieceItem = new ListViewItem();
            capturedPieceItem.ImageIndex = beyazTaslar.Images.Count - 1;

            beyazTaslarListesi.Items.Add(capturedPieceItem);

        }

        public void UpdateBlackDeathPiece( Image siyahTasResmi)
        {

            Image capturedPieceImage2 = siyahTasResmi;
            siyahTaslar.Images.Add(capturedPieceImage2);

            ListViewItem capturedPieceItem2 = new ListViewItem();
            capturedPieceItem2.ImageIndex = siyahTaslar.Images.Count - 1;

            listView1.Items.Add(capturedPieceItem2);
        }

        private void playerInfoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
