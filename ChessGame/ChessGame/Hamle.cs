using ChessGame.Taslar;

namespace ChessGame
{
    public class Hamle
    {
        public Tas Tas { get; set; }
        public Pozisyon BaslangicPozisyonu { get; set; }
        public Pozisyon BitisPozisyonu { get; set; }
        public Tas VurulanTas { get; set; }
        public bool VurduMu { get; set; }
        public bool SahMatMi { get; set; }

        public Hamle(Tas tas, Pozisyon baslangicPozisyonu, Pozisyon bitisPozisyonu, Tas vurulanTas = null, bool vurduMu = false, bool sahMatMi = false)
        {
            Tas = tas;
            BaslangicPozisyonu = baslangicPozisyonu;
            BitisPozisyonu = bitisPozisyonu;
            VurulanTas = vurulanTas;
            VurduMu = vurduMu;
            SahMatMi = sahMatMi;
        }
    }

}