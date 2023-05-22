using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ChessGame.Taslar;

namespace ChessGame
{
    public class InputHandler
    {
        private ChessBoard board;
        private ChessPiece selectedPiece;

        public InputHandler(ChessBoard board)
        {
            selectedPiece = null;
            this.board = board;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            Player currentPlayer = board.GameManager.GetCurrentPlayer();
            
            // Eğer seçilmiş bir taş yok ise, tıklanan hücredeki taşı seçeriz
            if (selectedPiece == null)
            {
                ChessPiece piece = board.GetPieceAtPosition(position.Item1, position.Item2);
                if (piece != null)
                {
                    // Hamle sırası kontrolü
                    if (piece.Color == currentPlayer.Color)
                    {
                        selectedPiece = piece;
                        selectedPiece.IsSelected = true;
                        button.BackColor = Color.Bisque;
                    }
                }
            }
            else if (board.IsKingInCheck(currentPlayer.Color, board))
            {
                if (!board.IsCheckmateForPiece(selectedPiece,selectedPiece.Color,board))
                {
                    MessageBox.Show("selected not null");
                    board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
                    if (selectedPiece.Type == ChessPieceType.Piyon)
                    {
                        selectedPiece.IsFirstMove = false;
                    }
                    board.UpdateBoard();
                    // Hamle sırasını değiştir
                    board.GameManager.ChangeTurn();
                    selectedPiece = null;
                }
                else
                {
                    MessageBox.Show("selected null");
                    selectedPiece = null;
                }
            }
            else // Eğer seçilmiş bir taş var ise, tıklanan hücreye gidip gidemeyeceğini kontrol ederiz
            {

                if (selectedPiece.CanMove(position.Item1, position.Item2, board))
                {
                    var color = currentPlayer.Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    // Taşı hareket ettiririz
                    
                    board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
                    if (selectedPiece.Type == ChessPieceType.Piyon)
                    {
                        selectedPiece.IsFirstMove = false;
                    }
                    board.UpdateBoard();
                    
                    if (board.IsKingInCheck(color, board))
                    {
                        string winner = (board.GameManager.GetCurrentPlayer().Color == PieceColor.White) ? "Beyaz" : "Siyah";
                        MessageBox.Show($"{winner} Şah çekti!");
                    }
                    // Hamle sırasını değiştir
                    board.GameManager.ChangeTurn();
                    selectedPiece = null;
                }
                else
                {
                    selectedPiece = null;
                }
            }
        }
    }
}
