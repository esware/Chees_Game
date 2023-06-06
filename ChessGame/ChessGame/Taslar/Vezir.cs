using System;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Vezir : ChessPiece
    {
        public Vezir(PieceColor color, ChessPieceType type, int row, int col, Button btn) : base(color, type, row, col, btn)
        {
        }
        
        public override bool CanMove(int toRow, int toCol, ChessBoard board)
        {

            // Aynı konumda kalma durumu
            if (CurrentRow == toRow && CurrentColumn == toCol)
            {
                return false;
            }

            // Hedef konumda kendi takımının bir taşı var mı?
            ChessPiece targetPiece = board.GetPieceAtPosition(toRow, toCol);
            if (targetPiece != null && targetPiece.Color == Color)
            {
                return false;
            }

            // Vezirin hareketi, kale veya fil hareketi gibi olabilir
            return CanMoveLikeRook(toRow, toCol, board) || CanMoveLikeBishop(toRow, toCol, board);
        }

        private bool CanMoveLikeRook(int toRow, int toCol, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - toRow);
            int colDiff = Math.Abs(CurrentColumn - toCol);

            if (rowDiff == 0 || colDiff == 0)
            {
                ChessPiece targetPiece = board.GetPieceAtPosition(toRow, toCol);
                if (targetPiece == null || targetPiece.Color != this.Color)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMoveLikeBishop(int row, int col, ChessBoard board)
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
                        return false;

                    currentRow += rowDirection;
                    currentCol += colDirection;
                }

                ChessPiece targetPiece = board.GetPieceAtPosition(row, col);
                if (targetPiece == null || targetPiece.Color != this.Color)
                    return true;
            }

            return false;
        }
    }
}