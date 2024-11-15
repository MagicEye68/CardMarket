using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository.Model
{
    public class Recensione
    {
        public int Id { get; set; }
        public string Testo { get; set; }
        public int Voto { get; set; }
        public int Pagamento { get; set; }
        public Pagamento Pagamentofk { get; set; }

    }
}
