using Microsoft.Extensions.DependencyInjection;

namespace Annunci.Business.Kafka
{
    public class KafkaTopicsOutput : AbstractKafkaTopics
    {
        public string Inserzioni { get; set; } = "Annuncio";
        public override IEnumerable<string> GetTopics() => new List<string>() { Inserzioni };
    }

    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string Utente { get; set; } = "Utente";

        public override IEnumerable<string> GetTopics() => new List<string>() { Utente };

    }


}
