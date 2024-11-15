using Annunci.Repository.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.MessageHandlers;

namespace Annunci.Business.Kafka.MessageHandlers
{
    public abstract class AbstractMessageHandler<TMessageDTO>
        : AbstractOperationMessageHandler<TMessageDTO, IRepository>
        where TMessageDTO : class, new()
    {

        protected AbstractMessageHandler(ILogger<AbstractMessageHandler<TMessageDTO>> logger, IRepository repository) : base(logger, repository) { }

        protected override async Task InsertAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Insert del DTO {domainDTOType}...", MessageDtoType);
            await InsertDtoAsync(messageDto, cancellationToken);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Insert del DTO {domainDTOType} completata!", MessageDtoType);
        }


        protected override async Task UpdateAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Update del DTO {domainDTOType}...", MessageDtoType);
            await UpdateDtoAsync(messageDto, cancellationToken);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Update del DTO {domainDTOType} completata", MessageDtoType);
        }

        protected override async Task DeleteAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Delete del DTO {domainDTOType}...", MessageDtoType);
            await DeleteDtoAsync(messageDto, cancellationToken);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Delete del DTO {domainDTOType} completata", MessageDtoType);
        }

        protected abstract Task InsertDtoAsync(TMessageDTO domainDto, CancellationToken cancellationToken = default);

        protected abstract Task UpdateDtoAsync(TMessageDTO domainDto, CancellationToken cancellationToken = default);

        protected abstract Task DeleteDtoAsync(TMessageDTO domainDto, CancellationToken cancellationToken = default);
    }
}
