using Microsoft.Extensions.DependencyInjection;

namespace Autenticazione.Business.Kafka
{
    public class KafkaTopicsOutput : AbstractKafkaTopics
    {
        public string Usernames { get; set; } = "Utente";
        public override IEnumerable<string> GetTopics() => new List<string>() { Usernames };
    }
}
