using Microsoft.Extensions.Logging;
using Transazioni.Repository.Abstractions;
using Transazioni.Repository.Model;
using Transazioni.Shared;

namespace Transazioni.Business.Kafka.MessageHandlers
{
    public class UtenteKafkaMessageHandler : AbstractMessageHandler<UtenteKafkaDto>
    {

        public UtenteKafkaMessageHandler(ILogger<UtenteKafkaMessageHandler> logger, IRepository repository) : base(logger, repository) { }

        protected override async Task InsertDtoAsync(UtenteKafkaDto messageDto, CancellationToken cancellationToken = default)
        {
            Utente message = new Utente
            {
                Id = messageDto.guid,
            };
            await Repository.AddUtente(message);
        }
        protected override async Task UpdateDtoAsync(UtenteKafkaDto messageDto, CancellationToken cancellationToken = default)
        {


        }
        protected override async Task DeleteDtoAsync(UtenteKafkaDto messageDto, CancellationToken cancellationToken = default)
        {

        }
    }
}
