using System;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Vezir : ChessPiece
    {
        public Vezir(PieceColor color, ChessPieceType type, int row, int col, Button btn) : base(color, type, row, col, btn)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {

            int rowDiff = Math.Abs(row - CurrentRow);
            int colDiff = Math.Abs(col - CurrentColumn);

            if (rowDiff != 0 && colDiff != 0 && rowDiff != colDiff)
            {
                return false; // Vezir sadece düz, çapraz veya yatay hareket edebilir.
            }

            int rowDirection = 0;
            int colDirection = 0;

            if (row != CurrentRow)
            {
                rowDirection = (row - CurrentRow) / rowDiff;
            }

            if (col != CurrentColumn)
            {
                colDirection = (col - CurrentColumn) / colDiff;
            }

            int currentRow = CurrentRow + rowDirection;
            int currentCol = CurrentColumn + colDirection;

            while (currentRow != row || currentCol != col)
            {
                if (board.IsOccupied(currentRow, currentCol))
                {
                    return false; // Geçişte herhangi bir taş varsa, hedef hücreye gidemez.
                }

                currentRow += rowDirection;
                currentCol += colDirection;
            }

   
            return true; // Geçerli bir hamle, hiçbir taş olmadan hedef hücreye ulaşabilir.
        }


    }

}