using System;

namespace ChessGame.Taslar
{
    public class Kral : ChessPiece
    {
        public Kral(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
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
                return true;
            }

            return false;
        }
    }

}