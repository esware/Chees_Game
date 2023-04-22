using System;

namespace ChessGame.Taslar
{
    public class Kale : Tas
    {
        public Renk Renk { get; set; }
        public Pozisyon Pozisyon { get; set; }
        public bool IlkHamleMi { get; set; }

        public Kale(Renk renk, Pozisyon pozisyon)
        {
            Renk = renk;
            Pozisyon = pozisyon;
            IlkHamleMi = true;
        }

        public override bool HaraketEdebilirMi(Pozisyon yeniPozisyon)
        {
            int farkX = Math.Abs(yeniPozisyon.X - Pozisyon.X);
            int farkY = Math.Abs(yeniPozisyon.Y - Pozisyon.Y);

            if (farkX == 0 && farkY > 0 || farkX > 0 && farkY == 0)
            {
                // Kale bu pozisyona hareket edebilir.
                return true;
            }

            return false;
        }

        public override void HaraketEt(Pozisyon yeniPozisyon)
        {
            if (HaraketEdebilirMi(yeniPozisyon))
            {
                Pozisyon = yeniPozisyon;
                IlkHamleMi = false;
            }
            else
            {
                throw new Exception("Kale bu pozisyona hareket edemez!");
            }
        }
    }

}