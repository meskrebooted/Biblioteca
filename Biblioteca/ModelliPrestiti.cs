using System;
using System.ComponentModel;

namespace Biblioteca
{
    public enum StatoRichiesta
    {
        InAttesa,
        Approvata,
        Rifiutata
    }

    public sealed class RichiestaPrestito
    {
        public RichiestaPrestito(int id, string utente, string libro, string fonte, DateTime dataCreazione)
        {
            Id = id;
            Utente = utente;
            Libro = libro;
            Fonte = fonte;
            DataCreazione = dataCreazione;
            Stato = StatoRichiesta.InAttesa;
        }

        public int Id { get; }
        public string Utente { get; }
        public string Libro { get; }
        public string Fonte { get; }
        public DateTime DataCreazione { get; }
        public StatoRichiesta Stato { get; set; }
    }

    public sealed class LibroCatalogo : INotifyPropertyChanged
    {
        private int _disponibili;

        public LibroCatalogo(string titolo, int totale)
        {
            Titolo = titolo;
            Totale = totale;
            _disponibili = totale;
        }

        public string Titolo { get; }
        public int Totale { get; }

        public int Disponibili
        {
            get => _disponibili;
            set
            {
                if (_disponibili == value)
                {
                    return;
                }
                _disponibili = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disponibili)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
