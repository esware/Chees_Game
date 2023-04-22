using System.Collections.Generic;

namespace ChessGame.Taslar
{
    public class Piyon:Tas
    {
        public Renk Renk { get; set; } 
        public Pozisyon Pozisyon { get; set; } 

        public Piyon(Renk renk, Pozisyon pozisyon)
        {
            Renk = renk;
            Pozisyon = pozisyon;
        }

        public override bool HaraketEdebilirMi(Pozisyon yeniPozisyon)
        {
            throw new System.NotImplementedException();
        }

        public override void HaraketEt(Pozisyon yeniPozisyon)
        {
            throw new System.NotImplementedException();
        }
    }
}