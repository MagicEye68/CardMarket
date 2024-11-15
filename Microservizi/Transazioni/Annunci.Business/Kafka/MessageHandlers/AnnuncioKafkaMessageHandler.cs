using Microsoft.Extensions.Logging;
using Transazioni.Repository.Abstractions;
using Transazioni.Repository.Model;
using Transazioni.Shared;

namespace Transazioni.Business.Kafka.MessageHandlers
{
    public class AnnuncioKafkaMessageHandler : AbstractMessageHandler<AnnuncioKafkaDto>
    {

        public AnnuncioKafkaMessageHandler(ILogger<AnnuncioKafkaMessageHandler> logger, IRepository repository) : base(logger, repository) { }

        protected override async Task InsertDtoAsync(AnnuncioKafkaDto messageDto, CancellationToken cancellationToken = default)
        {
            Annuncio message = new Annuncio
            {
                Id = messageDto.Id,
                Venditore = messageDto.Venditore,
            };
            await Repository.AddAnnuncio(message);
        }
        protected override async Task UpdateDtoAsync(AnnuncioKafkaDto messageDto, CancellationToken cancellationToken = default)
        {


        }
        protected override async Task DeleteDtoAsync(AnnuncioKafkaDto messageDto, CancellationToken cancellationToken = default)
        {

        }
    }
}
