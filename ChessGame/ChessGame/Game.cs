using ChessGame.Taslar;

namespace ChessGame
{
    public class Game
    {
        private Player[] players;
        private int currentPlayerIndex;

        public Game()
        {
            Player player1 = new Player("Beyaz", PieceColor.White);
            Player player2 = new Player("Siyah", PieceColor.Black);

            players = new[] { player1, player2 };
            currentPlayerIndex = 0; // İlk oyuncuyla başlayın
        }

        public Player GetCurrentPlayer()
        {
            return players[currentPlayerIndex];
        }

        public void ChangeTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        }

    }
}