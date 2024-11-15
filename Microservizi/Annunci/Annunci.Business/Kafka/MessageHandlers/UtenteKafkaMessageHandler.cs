using Annunci.Repository.Abstractions;
using Annunci.Repository.Model;
using Annunci.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Business.Kafka.MessageHandlers
{
    public class UtenteKafkaMessageHandler : AbstractMessageHandler<UtenteKafkaDto>
    {

        public UtenteKafkaMessageHandler(ILogger<UtenteKafkaMessageHandler> logger, IRepository repository) : base(logger, repository) { }

        protected override async Task InsertDtoAsync(UtenteKafkaDto messageDto, CancellationToken cancellationToken = default)
        {
            Utente message = new Utente
            {
                Username = messageDto.username,
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
