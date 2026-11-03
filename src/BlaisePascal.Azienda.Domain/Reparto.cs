using System;
namespace BlaisePascal.Azienda.Domain
{
    public class Reparto
    {
        string[] dipendenti;
        int[,] registroOre;
        string[][] progetti;


        private const int giorniSettimana = 7;

        public Reparto(string[] dipendenteDaAggiungere)
        {
            dipendenti = new string[dipendenteDaAggiungere.Length];
            for (int i = 0; i < dipendenteDaAggiungere.Length; i++)
            {
                dipendenti[i] = dipendenteDaAggiungere[i];
            }

            registroOre = new int[dipendenteDaAggiungere.Length, giorniSettimana];

            progetti = new string[dipendenteDaAggiungere.Length][];
            for (int i = 0; i < dipendenteDaAggiungere.Length; i++)
            {
                progetti[i] = new string[0];
            }
        }

        public void AggiungiOre(int indiceDipendente, int giorno, int ore)
        {
            if (indiceDipendente < 0 || indiceDipendente >= dipendenti.Length)
            {
                throw new ArgumentOutOfRangeException("Indice del dipendente non valido.");
            }
            if (giorno < 0 || giorno >= giorniSettimana)
            {
                throw new ArgumentOutOfRangeException("Giorno della settimana non valido.");
            }
            if (ore < 0 || ore > 10)
            {
                throw new ArgumentOutOfRangeException("Le ore non possono essere negative o maggiori di 10.");
            }
            registroOre[indiceDipendente, giorno] += ore;
        }

        public int CalcolaOreTotaliDipendente(int indiceDipendente)
        {
            if (indiceDipendente < 0 || indiceDipendente >= dipendenti.Length)
            {
                throw new ArgumentOutOfRangeException("Indice del dipendente non valido.");
            }
            int oreTotali = 0;
            for (int i = 0; i < giorniSettimana; i++)
            {
                oreTotali += registroOre[indiceDipendente, i];
            }
            return oreTotali;
        }

        public void AggiungiProgetto(int indiceDipendente, string progetto)
        {
            if (indiceDipendente < 0 || indiceDipendente >= dipendenti.Length)
            {
                throw new ArgumentOutOfRangeException("Indice del dipendente non valido.");
            }
            if (string.IsNullOrWhiteSpace(progetto))
            {
                throw new ArgumentException("Il nome del progetto non può essere vuoto.");
            }

            string[] progettiCorrenti = progetti[indiceDipendente];
            string[] nuovoArrayProgetti = new string[progettiCorrenti.Length + 1];

            for (int i = 0; i < progettiCorrenti.Length; i++)
            {
                nuovoArrayProgetti[i] = progettiCorrenti[i];
            }
            // Inserimento del nuovo progetto in ultima posizione
            nuovoArrayProgetti[nuovoArrayProgetti.Length - 1] = progetto;

            // Riassegnazione del jagged array
            progetti[indiceDipendente] = nuovoArrayProgetti;
        }

        public void RimuoviProgetto(int indiceDipendente, string progetto)
        {
            if (indiceDipendente < 0 || indiceDipendente >= dipendenti.Length)
            {
                throw new ArgumentOutOfRangeException("Indice del dipendente non valido.");
            }
            if (string.IsNullOrWhiteSpace(progetto))
            {
                throw new ArgumentException("Il nome del progetto non può essere vuoto.");
            }
            string[] progettiCorrenti = progetti[indiceDipendente];
            int indexToRemove = Array.IndexOf(progettiCorrenti, progetto);
            if (indexToRemove == -1)
            {
                throw new ArgumentException("Il progetto specificato non esiste per questo dipendente.");
            }
            string[] nuovoArrayProgetti = new string[progettiCorrenti.Length - 1];
            for (int i = 0, j = 0; i < progettiCorrenti.Length; i++)
            {
                if (i != indexToRemove)
                {
                    nuovoArrayProgetti[j++] = progettiCorrenti[i];
                }
            }
            // Riassegnazione del jagged array
            progetti[indiceDipendente] = nuovoArrayProgetti;
        }

        public int CalcoloOreTotaliDelReparto()
        {
            int oreTotaliReparto = 0;
            for (int i = 0; i < dipendenti.Length; i++)
            {
                oreTotaliReparto += CalcolaOreTotaliDipendente(i);
            }

            return oreTotaliReparto;
        }


    }
}
