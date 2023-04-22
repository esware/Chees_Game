using System;
using System.Collections.Generic;
using ChessGame.Taslar;
using System.Linq;

namespace ChessGame
{
    public class Tahta
    {
        private Tas[,] tahta;
        private List<Tas> taslar = new List<Tas>();
        private Stack<(Pozisyon, Pozisyon)> gecmisPozisyonlar;

        public Tahta()
        {
            tahta = new Tas[8, 8];

            // Siyah taşları yerleştirme
            tahta[0, 0] = new Kale(Renk.Siyah, new Pozisyon(0, 0));
            tahta[0, 1] = new At(Renk.Siyah, new Pozisyon(0, 1));
            tahta[0, 2] = new Fil(Renk.Siyah, new Pozisyon(0, 2));
            tahta[0, 3] = new Vezir(Renk.Siyah, new Pozisyon(0, 3));
            tahta[0, 4] = new Kral(Renk.Siyah, new Pozisyon(0, 4));
            tahta[0, 5] = new Fil(Renk.Siyah, new Pozisyon(0, 5));
            tahta[0, 6] = new At(Renk.Siyah, new Pozisyon(0, 6));
            tahta[0, 7] = new Kale(Renk.Siyah, new Pozisyon(0, 7));

            for (int i = 0; i < 8; i++)
            {
                tahta[1, i] = new Piyon(Renk.Siyah, new Pozisyon(1, i));
            }

            // Beyaz taşları yerleştirme
            tahta[7, 0] = new Kale(Renk.Beyaz, new Pozisyon(7, 0));
            tahta[7, 1] = new At(Renk.Beyaz, new Pozisyon(7, 1));
            tahta[7, 2] = new Fil(Renk.Beyaz, new Pozisyon(7, 2));
            tahta[7, 3] = new Vezir(Renk.Beyaz, new Pozisyon(7, 3));
            tahta[7, 4] = new Kral(Renk.Beyaz, new Pozisyon(7, 4));
            tahta[7, 5] = new Fil(Renk.Beyaz, new Pozisyon(7, 5));
            tahta[7, 6] = new At(Renk.Beyaz, new Pozisyon(7, 6));
            tahta[7, 7] = new Kale(Renk.Beyaz, new Pozisyon(7, 7));

            for (int i = 0; i < 8; i++)
            {
                tahta[6, i] = new Piyon(Renk.Beyaz, new Pozisyon(6, i));
            }
        }
        
        public Tas GetTas(Pozisyon pozisyon)
        {
            return tahta[pozisyon.X, pozisyon.Y];
        }

        public void SetTas(Pozisyon pozisyon, Tas tas)
        {
            tahta[pozisyon.X, pozisyon.Y] = tas;
        }
        public bool TasHareketEdebilirMi(Pozisyon mevcutPozisyon, Pozisyon yeniPozisyon)
        {
            var tas = GetTas(mevcutPozisyon);
            if (tas != null)
            {
                return tas.HaraketEdebilirMi(yeniPozisyon);
            }
            return false;
        }

        public void PozisyonKaydet(Pozisyon mevcutPozisyon, Pozisyon yeniPozisyon)
        {
            gecmisPozisyonlar.Push((mevcutPozisyon, yeniPozisyon));
        }

        public void PozisyonGeriAl()
        {
            if (gecmisPozisyonlar.Count > 0)
            {
                var gecmisPozisyon = gecmisPozisyonlar.Pop();
                var tas = GetTas(gecmisPozisyon.Item2);
                tas.HaraketEt(gecmisPozisyon.Item1);
                SetTas(gecmisPozisyon.Item2, null);
                SetTas(gecmisPozisyon.Item1, tas);
            }
        }
        
        public class HamleGecmisi
        {
            private List<string> hamleler = new List<string>();

            public void HamleGecmisiniKaydet(string hamle)
            {
                hamleler.Add(hamle);
            }

            public void HamleGecmisiniGoster()
            {
                Console.WriteLine("Hamle Geçmişi:");
                for (int i = 0; i < hamleler.Count; i++)
                {
                    Console.WriteLine("{0}. Hamle: {1}", i + 1, hamleler[i]);
                }
            }
        }
        
        public void TahtayiCiz()
        {
            Console.WriteLine("  A B C D E F G H");
            for (int i = 1; i <= 8; i++)
            {
                Console.Write(i + " ");
                for (int j = 1; j <= 8; j++)
                {
                    Pozisyon pozisyon = new Pozisyon(j, i);
                    Tas tas = GetTas(pozisyon);
                    if (tas == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tas.Renk == Renk.Beyaz ? "B" : "S");
                        Console.Write(tas.GetType().Name[0] + " ");
                    }
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public List<Pozisyon> MevcutHamleleriDondur(Renk renk)
        {
            List<Pozisyon> mevcutHamleler = new List<Pozisyon>();

            foreach (Tas tas in taslar.Where(x => x.Renk == renk))
            {
                for (int i = 1; i <= 8; i++)
                {
                    for (int j = 1; j <= 8; j++)
                    {
                        Pozisyon yeniPozisyon = new Pozisyon(i, j);

                        if (TasHareketEdebilirMi(tas.Pozisyon, yeniPozisyon))
                        {
                            mevcutHamleler.Add(yeniPozisyon);
                        }
                    }
                }
            }

            return mevcutHamleler;
        }


        public bool HamleYap(Renk siradakiOyuncu, Pozisyon kaynakPozisyon, Pozisyon hedefPozisyon)
        {
            

            return true;
        }

    }
}