using System;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Kale : ChessPiece
    {
        public Kale(PieceColor color, ChessPieceType type, int row, int col, Button btn) : base(color, type, row, col, btn)
        {
        }
        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);

            if (rowDiff == 0 || colDiff == 0)
            {
                ChessPiece targetPiece = board.GetPieceAtPosition(row, col);
                if (targetPiece == null || targetPiece.Color != this.Color)
                {
                    return true;
                }
            }

            return false;
        }


    }

}