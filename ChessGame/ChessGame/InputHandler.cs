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
            Tuple<int, int> position = (Tuple<int,int>)button.Tag;

            // Eğer seçilmiş bir taş yok ise, tıklanan hücredeki taşı seçeriz
            if (selectedPiece == null)
            {
                ChessPiece piece = board.GetPieceAtPosition(position.Item1, position.Item2);
                if (piece != null)
                {
                    // Hamle sırası kontrolü
                    Player currentPlayer = board.game.GetCurrentPlayer();
                    if (board.IsKingInCheck(currentPlayer.Color, board))
                    {
                        
                    }
                    
                    
                    if (piece.Color == currentPlayer.Color)
                    {
                        selectedPiece = piece;
                        selectedPiece.IsSelected = true;
                        button.BackColor = Color.Bisque;
                    }
                }
            }
            else // Eğer seçilmiş bir taş var ise, tıklanan hücreye gidip gidemeyeceğini kontrol ederiz
            {
                if (selectedPiece.CanMove(position.Item1, position.Item2, board))
                {
                    // Taşı hareket ettiririz
                    board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
                    if (selectedPiece.Type == ChessPieceType.Piyon)
                    {
                        selectedPiece.IsFirstMove = false;
                    }
                    board.UpdateBoard();
                    Player currentPlayer = board.game.GetCurrentPlayer();
                    var color = currentPlayer.Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    if (board.IsKingInCheck(color, board))
                    {
                        string winner = (board.game.GetCurrentPlayer().Color == PieceColor.White) ? "Beyaz" : "Siyah";
                        MessageBox.Show($"{winner} Sah cekti!");
                    }
                    // Hamle sırasını değiştir
                    board.game.ChangeTurn();
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