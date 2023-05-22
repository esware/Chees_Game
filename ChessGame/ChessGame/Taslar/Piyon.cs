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
                    // Eğer hedef hücre dolu ise hareket engellenir
                    if (!board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }
                
                else if (rowDiff == 1 && colDiff == 0)
                {
                    // Eğer hedef hücre dolu ise hareket engellenir
                    if (!board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }
                else if (rowDiff == 1 && Math.Abs(colDiff) == 1)
                {
                    // Eğer hedef hücrede rakip taş varsa piyon taşıyı yiyor
                    if (board.IsOccupied(row, col) && board.GetPieceAtPosition(row, col).Color == PieceColor.Black)
                    {
                        return true;
                    }
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
                    // Eğer hedef hücre dolu ise hareket engellenir
                    if (!board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }
                else if (rowDiff == -1 && colDiff == 0)
                {
                    // Eğer hedef hücre dolu ise hareket engellenir
                    if (!board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }
                else if (rowDiff == -1 && Math.Abs(colDiff) == 1)
                {
                    // Eğer hedef hücrede rakip taş varsa piyon taşıyı yiyor
                    if (board.IsOccupied(row, col) && board.GetPieceAtPosition(row, col).Color == PieceColor.White)
                    {
                        return true;
                    }
                }
                
            }
            
            return false;
        }

        public bool CanMoves(int row, int col, ChessBoard board)
        {
            int rowDiff = CurrentRow - row;
            int colDiff = CurrentColumn - col;
            bool notDiff = colDiff == 0 && rowDiff == 0;
            
            if (IsFirstMove && colDiff == 0 && rowDiff == 2)
            {
                if (notDiff)
                {
                    return false;
                }
                // Eğer hedef hücre dolu ise hareket engellenir
                if (!board.IsOccupied(row, col))
                {
                    return true;
                }
            }
                
            else if (rowDiff == 1 && colDiff == 0)
            {
                // Eğer hedef hücre dolu ise hareket engellenir
                if (!board.IsOccupied(row, col))
                {
                    return true;
                }
            }
            else if (rowDiff == 1 && Math.Abs(colDiff) == 1)
            {
                // Eğer hedef hücrede rakip taş varsa piyon taşıyı yiyor
                if (board.IsOccupied(row, col) && board.GetPieceAtPosition(row, col).Color == PieceColor.Black)
                {
                    return true;
                }
            }

            return false;
        }

    }
}