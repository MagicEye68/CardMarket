using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository.Model
{
    public class Utente
    {
        public string Id { get; set; }
        public ICollection<Annuncio> Annunci { get; set; } = new List<Annuncio>();
        public ICollection<Pagamento> Pagamenti { get; set; } = new List<Pagamento>();
    }
}
