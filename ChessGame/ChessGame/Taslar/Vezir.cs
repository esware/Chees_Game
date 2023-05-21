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
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);
            bool notDiff = colDiff == 0 && rowDiff == 0;




        if (rowDiff == colDiff || (rowDiff == 0 || colDiff == 0))
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