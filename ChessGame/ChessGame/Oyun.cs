using System;
using System.Collections.Generic;

namespace ChessGame
{
    public class Oyun
{
    private Tahta tahta;
    private Renk siradakiOyuncu;
    private List<Hamle> hamleGecmisi;

    public Oyun()
    {
        tahta = new Tahta();
        siradakiOyuncu = Renk.Beyaz;
        hamleGecmisi = new List<Hamle>();
    }

    public void Oyna()
    {
        Console.WriteLine("Oyuna başla!");
        while (true)
        {
            Console.WriteLine("\n===================================");
            Console.WriteLine("Sıradaki oyuncu: " + siradakiOyuncu);

            tahta.TahtayiCiz();
            Console.WriteLine("===================================");

            Console.Write("Hangi taşı oynayacaksınız? (örnek: e2): ");

            Console.Write("Hangi pozisyona taşın gitmesini istersiniz? (örnek: e4): ");

            siradakiOyuncu = siradakiOyuncu == Renk.Beyaz ? Renk.Siyah : Renk.Beyaz;
        }

        Console.WriteLine("\nHamle geçmişi:");
        HamleGecmisiniGoster();
    }

    private void HamleGecmisiniGoster()
    {
        foreach (Hamle hamle in hamleGecmisi)
        {
        }
    }
}

}