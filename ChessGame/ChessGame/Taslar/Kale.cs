using System;

namespace ChessGame.Taslar
{
    public class Kale : ChessPiece
    {
        public Kale(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);
            bool notDiff = colDiff == 0 && rowDiff == 0;

            if ((rowDiff == 0 || colDiff == 0))
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