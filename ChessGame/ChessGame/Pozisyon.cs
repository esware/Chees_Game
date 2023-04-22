namespace ChessGame
{
    public enum Renk
    {
        Siyah,
        Beyaz
    }
    public class Pozisyon
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pozisyon(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}