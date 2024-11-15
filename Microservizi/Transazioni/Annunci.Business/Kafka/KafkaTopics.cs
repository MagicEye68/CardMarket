using Microsoft.Extensions.DependencyInjection;

namespace Transazioni.Business.Kafka
{
    public class  KafkaTopicsOutput : AbstractKafkaTopics
    {
        public string Pagamenti { get; set; } = "Pagamento";
        public override IEnumerable<string> GetTopics() => new List<string>() { Pagamenti };
    }

    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string Utente { get; set; } = "Utente";
        public string Annuncio { get; set; } = "Annuncio";

        public override IEnumerable<string> GetTopics() => new List<string>() { Utente, Annuncio};

    }
}
