using System;
using System.Drawing;

namespace ChessGame.Taslar
{
    public class At : ChessPiece
    {
        public At(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }

}