using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository.Model
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int Annuncio { get; set; }
        public string Compratore { get; set; }
        public Recensione? Recensione { get; set; }
        public Annuncio Annunciofk { get; set; }
        public Utente Compratorefk { get; set; }
    }
}
