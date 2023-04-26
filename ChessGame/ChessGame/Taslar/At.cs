using System;
using System.Drawing;

namespace ChessGame.Taslar
{
    public class At : ChessPiece
    {
        public At(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
            
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);
            
            if (rowDiff == 1 && colDiff == 2)
            {
                return true;
            }
            else if (rowDiff == 2 && colDiff == 1)
            {
                return true;
            }

            return false;
        }
    }

}