using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame.Taslar
{
    public class Piyon:ChessPiece
    {
        public Piyon(PieceColor color, ChessPieceType type, int row, int col,Button btn) : base(color, type, row, col,btn)
        {
            
        }
        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = Math.Abs(CurrentRow - row);
            int colDiff = Math.Abs(CurrentColumn - col);

            if (this.Color == PieceColor.White)
            {
                if (IsFirstMove && colDiff == 0 && rowDiff == 2 && !board.IsOccupied(row, col))
                    return true;

                if (rowDiff == 1 && colDiff == 0 && !board.IsOccupied(row, col))
                    return true;

                if (rowDiff == 1 && colDiff == 1 && board.IsOccupied(row, col) && board.GetPieceAtPosition(row, col).Color == PieceColor.Black)
                    return true;
            }
            else if (this.Color == PieceColor.Black)
            {
                if (IsFirstMove && colDiff == 0 && rowDiff == 2 && !board.IsOccupied(row, col))
                    return true;

                if (rowDiff == 1 && colDiff == 0 && !board.IsOccupied(row, col))
                    return true;

                if (rowDiff == 1 && colDiff == 1 && board.IsOccupied(row, col) && board.GetPieceAtPosition(row, col).Color == PieceColor.White)
                    return true;
            }

            return false;
        }



    }
}