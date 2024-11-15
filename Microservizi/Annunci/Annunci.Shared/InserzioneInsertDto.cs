using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Shared
{
    public class InserzioneInsertDto
    {
        public string Carta { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Rarita { get; set; }
    }
}
