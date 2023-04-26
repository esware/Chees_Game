using System;

namespace ChessGame.Taslar
{
    public class Fil : ChessPiece
    {
        public Fil(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);
            bool notDiff = colDiff == 0 && rowDiff == 0;

            
            if (notDiff)
            {
                return false;
            }
            if (rowDiff == colDiff && rowDiff != 0)
            {
                return true;
            }
            
            return false;
        }
    }

}