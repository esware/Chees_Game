using System;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Kral : ChessPiece
    {
        public Kral(PieceColor color, ChessPieceType type, int row, int col,Button btn) : base(color, type, row, col,btn)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);
            bool notDiff = colDiff == 0 && rowDiff == 0;

            if ((rowDiff == 1 && colDiff == 1)||(rowDiff <= 1 && colDiff <= 1))
            {
                if (notDiff)
                {
                    return false;
                }
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