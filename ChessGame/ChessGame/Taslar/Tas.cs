using System.Drawing;

namespace ChessGame.Taslar
{
    public abstract class Tas
    {
        public Renk Renk { get; set; }
        public Pozisyon Pozisyon { get; set; }
        public bool IlkHamleMi { get; set; }
        
        public abstract bool HaraketEdebilirMi(Pozisyon yeniPozisyon);
        public abstract void HaraketEt(Pozisyon yeniPozisyon);
    }
}