using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Recensioni.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.Abstractions.MessageHandlers;
using Utility.Kafka.MessageHandlers;
using Utility.Kafka.Services;

namespace Recensioni.Business.Kafka.MessageHandlers
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly ILogger<ConsumerService<KafkaTopicsInput>> _logger;
        private readonly KafkaTopicsInput _optionsTopics;

        public MessageHandlerFactory(ILogger<ConsumerService<KafkaTopicsInput>> logger, IOptions<KafkaTopicsInput> optionsTopics)
        {
            _logger = logger;
            _optionsTopics = optionsTopics.Value;
        }

        public IMessageHandler Create(string topic, IServiceProvider serviceProvider)
        {

            if (topic == _optionsTopics.Utente)
            {
                return ActivatorUtilities.CreateInstance<UtenteKafkaMessageHandler>(serviceProvider);
            }
            if (topic == _optionsTopics.Annuncio)
            {
                return ActivatorUtilities.CreateInstance<AnnuncioKafkaMessageHandler>(serviceProvider);
            }
            if (topic == _optionsTopics.Pagamento)
            {
                return ActivatorUtilities.CreateInstance<PagamentoKafkaMessageHandler>(serviceProvider);
            }

            throw new ArgumentOutOfRangeException(nameof(topic), $"Il topic '{topic}' non è gestito");
        }
    }

}