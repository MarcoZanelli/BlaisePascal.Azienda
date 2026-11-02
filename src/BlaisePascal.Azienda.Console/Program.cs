using System;
using BlaisePascal.Azienda.Domain;
class Program
{
    static void Main()
    {
        string[] dipendentiIniziali = { "Mario Rossi", "Luigi Bianchi", "Anna Verde" };
        Reparto videogiochi = new Reparto(dipendentiIniziali);

        // Modifica ore
        videogiochi.AggiungiOre(0, 0, 8); // Lunedì: 8 ore
        videogiochi.AggiungiOre(0, 1, 7); // Martedì: 7 ore
        videogiochi.AggiungiOre(1, 0, 8); // Lunedì: 8 ore

        // Gestione progetti
        videogiochi.AggiungiProgetto(0, "Sviluppo App");
        videogiochi.AggiungiProgetto(0, "Migrazione Cloud");
        videogiochi.AggiungiProgetto(1, "Sviluppo App");

        // Calcolo ore
        Console.WriteLine($"Totale ore Mario Rossi: {videogiochi.CalcolaOreTotaliDipendente(0)}"); // 15
        Console.WriteLine($"Totale ore Reparto: {videogiochi.CalcoloOreTotaliDelReparto()}"); // 23

        // Rimozione progetto
        videogiochi.RimuoviProgetto(1, "Sviluppo App");
        Console.WriteLine("il progetto 'Sviluppo App' è stato rimosso dal dipendente Luigi Bianchi.");
    }
}
