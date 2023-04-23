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
            // Hedeflenen karede taş varsa piyon oraya gidemez.
            if (board.IsOccupied(row, col))
            {
                return false;
            }

            // Piyon yalnızca ileri doğru hareket edebilir.
            int rowDiff = this.CurrentRow-row;
            int colDiff = this.CurrentColumn-col;

            if (this.Color == PieceColor.White)
            {
                // Beyaz piyon sadece ileri hareket edebilir.
                if (rowDiff <= 0)
                {
                    return false;
                }

                // İlk hareketinde, piyon iki kare ileri gidebilir.
                if (this.IsFirstMove && rowDiff == 2 && colDiff == 0)
                {
                    // Ara kare boşsa ve piyonun yolu engellenmiyorsa, piyon ilerleyebilir.
                    int intermediateRow = this.CurrentRow - 1;
                    if (!board.IsOccupied(intermediateRow, this.CurrentColumn) && !board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }
                else
                {
                    // İleri hareket etmek isteyen piyonlar sadece bir kare ilerleyebilir.
                    if (rowDiff != 1 || colDiff != 0)
                    {
                        return false;
                    }
                }
                
            }
            else
            {
                // Siyah piyon sadece geri hareket edebilir.
                if (rowDiff >= 0)
                {
                    return false;
                }

                // İlk hareketinde, piyon iki kare geri gidebilir.
                if (this.IsFirstMove && rowDiff == -2 && colDiff == 0)
                {
                    // Ara kare boşsa ve piyonun yolu engellenmiyorsa, piyon ilerleyebilir.
                    int intermediateRow = this.CurrentRow - 1;
                    if (!board.IsOccupied(intermediateRow, this.CurrentColumn) && !board.IsOccupied(row, col))
                    {
                        return true;
                    }
                }

                // Geri hareket etmek isteyen piyonlar sadece bir kare geri ilerleyebilir.
                if (rowDiff != -1 || colDiff != 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}