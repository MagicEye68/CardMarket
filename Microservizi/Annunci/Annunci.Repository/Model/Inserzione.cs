using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository.Model
{
    public class Inserzione
    {
        public int Id { get; set; }
        public string Venditore { get; set; }
        public string Carta { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Rarita { get; set; }
        public Carta Cartafk { get; set; }
        public TipoRarita Raritafk { get; set; }
        public Utente Venditorefk { get; set; }
    }
}
