using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository.Model
{
    public class Annuncio
    {
        public int Id { get; set; }
        public string Venditore { get; set; }
        public Utente Venditorefk { get; set; }
        public ICollection<Pagamento> Pagamenti { get; set; } = new List<Pagamento>();

    }
}
