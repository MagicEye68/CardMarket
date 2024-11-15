using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository.Model
{
    public class TipoRarita
    {
        public string Rarita { get; set; }
        public ICollection<Inserzione> Inserzioni { get; set; } = new List<Inserzione>();
    }
}
