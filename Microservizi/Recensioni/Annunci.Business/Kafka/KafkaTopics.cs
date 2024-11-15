using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Business.Kafka
{
    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string Utente { get; set; } = "Utente";
        public string Annuncio { get; set; } = "Annuncio";
        public string Pagamento { get; set; } = "Pagamento";

        public override IEnumerable<string> GetTopics() => new List<string>() { Utente, Annuncio, Pagamento };

    }
}
