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
    public class PagamentoKafkaMessageHandler : AbstractMessageHandler<PagamentoKafkaDto>
    {

            public PagamentoKafkaMessageHandler(ILogger<PagamentoKafkaMessageHandler> logger, IRepository repository) : base(logger, repository) { }

            protected override async Task InsertDtoAsync(PagamentoKafkaDto messageDto, CancellationToken cancellationToken = default)
            {
            Pagamento message = new Pagamento
            {
                Id = messageDto.Id,
                Annuncio = messageDto.Annuncio,
                Compratore = messageDto.Compratore,
                
            };
                await Repository.AddPagamento(message);
            }
            protected override async Task UpdateDtoAsync(PagamentoKafkaDto messageDto, CancellationToken cancellationToken = default)
            {


            }
            protected override async Task DeleteDtoAsync(PagamentoKafkaDto messageDto, CancellationToken cancellationToken = default)
            {

            }
        }
    }

