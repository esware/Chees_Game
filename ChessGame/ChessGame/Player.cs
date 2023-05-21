using ChessGame.Taslar;

namespace ChessGame
{
    public class Player
    {
        public string Name { get; set; }
        public PieceColor Color { get; set; }
        public bool IsTurn { get; set; }

        public Player(string name, PieceColor color)
        {
            Name = name;
            Color = color;
            IsTurn = false;
        }
    }
}