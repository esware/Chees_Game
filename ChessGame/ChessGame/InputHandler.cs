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
        private Button _button;
        private Player currentPlayer;
        public InputHandler(ChessBoard board)
        {
            selectedPiece = null;
            this.board = board;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            _button = (Button)sender;
            Tuple<int, int> position = (Tuple<int, int>)_button.Tag;
            currentPlayer = board.GameManager.GetCurrentPlayer();

            // Seçili taşı kontrol et
            if (selectedPiece == null)
            {
                SelectPiece(position, currentPlayer);
            }
            else if (board.IsKingInCheck(currentPlayer.Color, board))
            {
                
                if (board.CanMoveInCheck(selectedPiece, selectedPiece.Color, board,position.Item1,position.Item2))
                {
                    MovePiece(position);
                }
                else
                {
                    ResetSelection();
                }
            }
            else
            {
                MovePiece(position);
            }
        }

        private void SelectPiece(Tuple<int, int> position, Player currentPlayer)
        {
            ChessPiece piece = board.GetPieceAtPosition(position.Item1, position.Item2);
            if (piece != null && piece.Color == currentPlayer.Color)
            {
                selectedPiece = piece;
                selectedPiece.IsSelected = true;
                _button.BackColor = Color.Bisque;
            }
        }

        private void MovePiece(Tuple<int, int> position)
        {
            if (selectedPiece.CanMove(position.Item1, position.Item2, board))
            {
                
                var color = currentPlayer.Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
                board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
                if (selectedPiece.Type == ChessPieceType.Piyon)
                {
                    selectedPiece.IsFirstMove = false;
                }
               

                if (board.IsKingInCheck(color, board))
                {
                    string winner = (board.GameManager.GetCurrentPlayer().Color == PieceColor.White) ? "Beyaz" : "Siyah";
                    MessageBox.Show($"{winner} Şah çekti!");
                }

                board.GameManager.ChangeTurn();
                selectedPiece = null;
            }
            else
            {
                ResetSelection();
            }
            board.UpdateBoard();
        }

        private void ResetSelection()
        {
            selectedPiece = null;
        }

    }
}
