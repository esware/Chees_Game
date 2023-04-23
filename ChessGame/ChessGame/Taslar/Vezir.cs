using System;

namespace ChessGame.Taslar
{
    public class Vezir : ChessPiece
    {
        public Vezir(PieceColor color, ChessPieceType type, int row, int col) : base(color, type, row, col)
        {
        }

        public override bool CanMove(int row, int col, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }

}