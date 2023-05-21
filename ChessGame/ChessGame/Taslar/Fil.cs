using System;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Fil : ChessPiece
    {
        public Fil(PieceColor color, ChessPieceType type, int row, int col,Button btn) : base(color, type, row, col,btn)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);

            if (rowDiff == colDiff && rowDiff != 0)
            {
                int rowDirection = (row - CurrentRow) / rowDiff;
                int colDirection = (col - CurrentColumn) / colDiff;

                int currentRow = CurrentRow + rowDirection;
                int currentCol = CurrentColumn + colDirection;

                while (currentRow != row && currentCol != col)
                {
                    if (board.IsOccupied(currentRow, currentCol))
                    {
                        return false;
                    }

                    currentRow += rowDirection;
                    currentCol += colDirection;
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