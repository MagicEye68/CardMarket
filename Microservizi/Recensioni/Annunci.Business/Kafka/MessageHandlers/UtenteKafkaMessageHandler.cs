using Microsoft.Extensions.Logging;
using Recensioni.Repository.Abstractions;
using Recensioni.Repository.Model;
using Recensioni.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Business.Kafka.MessageHandlers
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
