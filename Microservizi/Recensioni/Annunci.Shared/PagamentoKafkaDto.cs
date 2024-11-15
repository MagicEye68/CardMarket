using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Shared
{
    public class PagamentoKafkaDto
    {
        public int Id { get; set; }
        public int Annuncio { get; set; }
        public string Compratore { get; set; }
        public string Metodo { get; set; }
    }
}
