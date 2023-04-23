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

            if (selectedPiece == null)
            {
                selectedPiece = board.GetPieceAtPosition(position.Item1, position.Item2);
                button.BackColor = Color.Coral;
            }
            else
            {
                selectedPiece.IsSelected = true;
                if (selectedPiece.CanMove(position.Item1, position.Item2, board))
                {
                    board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
                    if (selectedPiece.Type == ChessPieceType.Piyon)
                    {
                        selectedPiece.IsFirstMove = false;
                    }
                    selectedPiece = null;
                    board.UpdateBoard();
                }
                else
                {
                    // seçili butonun rengini değiştirme
                    button.BackColor = Color.Blue;
                    selectedPiece = board.GetPieceAtPosition(position.Item1, position.Item2);
                }
            }
        }


    }

}