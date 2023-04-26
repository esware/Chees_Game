using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Taslar
{
    public class Piyon:ChessPiece
    {
        public Piyon(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
            
        }
        public override bool CanMove(int row, int col, ChessBoard board)
        {
            int rowDiff = CurrentRow - row;
            int colDiff = CurrentColumn - col;
            bool notDiff = colDiff == 0 && rowDiff == 0;

            if (this.Color == PieceColor.White)
            {
                if (IsFirstMove && colDiff == 0 && rowDiff == 2)
                {
                    if (notDiff)
                    {
                        return false;
                    }
                    return true;
                }
                
                else if (rowDiff == 1 && colDiff == 0)
                {
                    return true;
                }

            }
            if (this.Color == PieceColor.Black)
            {
                if (IsFirstMove && colDiff == 0 && rowDiff == -2)
                {
                    if (notDiff)
                    {
                        return false;
                    }
                    return true;
                }
                
                else if (rowDiff == -1 && colDiff == 0)
                {
                    return true;
                }
                
            }
            
            return false;
        }

    }
}