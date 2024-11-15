using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Shared
{
    public class InserzioneReadDto
    {
        public int Id { get; set; }
        public string Venditore { get; set; }
        public string Carta { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Rarita { get; set; }

        public InserzioneReadDto() { }
        public InserzioneReadDto(int id, string venditore, string carta, int quantita, decimal prezzo, string rarita)
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
