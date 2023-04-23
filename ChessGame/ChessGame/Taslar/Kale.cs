using System;

namespace ChessGame.Taslar
{
    public class Kale : ChessPiece
    {
        public Kale(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }

}