

namespace Annunci.Shared
{
    public class InserzioneDto
    {

        public int Id { get; set; }
        public string Venditore { get; set; }
        public string Carta { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Rarita { get; set; }

        public InserzioneDto() { }
        public InserzioneDto(int id, string venditore, string carta, int quantita, decimal prezzo, string rarita)
        {
            Id = id;
            Venditore = venditore;
            Carta = carta;
            Quantita = quantita;
            Prezzo = prezzo;
            Rarita = rarita;
        }


    }

}
