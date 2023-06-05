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

            int rowDirection = rowDiff == 0 ? 0 : (row - CurrentRow) / rowDiff;
            int colDirection = colDiff == 0 ? 0 : (col - CurrentColumn) / colDiff;

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

            ChessPiece targetPiece = board.GetPieceAtPosition(row, col);
            if (targetPiece == null)
            {
                return true; // Hedef hücre boş ise geçerli bir hamledir.
            }
            
            if (targetPiece.Color != this.Color)
            {
                return true; // Hedef hücredeki taş rakip taş ise geçerli bir hamledir.
            }

            return false; // Hedef hücrede aynı renkte bir taş var, geçersiz hamle.
        }



    }

}