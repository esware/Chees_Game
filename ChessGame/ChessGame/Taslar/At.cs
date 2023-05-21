using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class At : ChessPiece
    {

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);

            if ((rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2))
            {
                ChessPiece targetPiece = board.GetPieceAtPosition(row, col);
                if (targetPiece == null || targetPiece.Color != this.Color)
                {
                    return true;
                }
            }

            return false;
        }

        public At(PieceColor color, ChessPieceType type, int row, int col, Button btn) : base(color, type, row, col, btn)
        {
        }
    }

}