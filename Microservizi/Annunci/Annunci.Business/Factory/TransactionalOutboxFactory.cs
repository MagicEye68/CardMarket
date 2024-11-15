using Annunci.Repository.Model;
using Annunci.Shared;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility.Kafka.Constants;
using Utility.Kafka.Messages;

namespace Annunci.Business.Factory
{
    public class TransactionalOutboxFactory
    {
        public static TransactionalOutbox CreateAddAnnuncio(InserzioneDto dto) => Create(dto, Operations.Insert);

        private static TransactionalOutbox Create(InserzioneDto dto, string operation) => Create(nameof(Inserzione), dto, operation);


        private static TransactionalOutbox Create<TDTO>(string table, TDTO dto, string operation) where TDTO : class, new()
        {
            OperationMessage<TDTO> opMsg = new OperationMessage<TDTO>()
            {
                Dto = dto,
                Operation = operation
            };
            opMsg.CheckMessage();

            return new TransactionalOutbox()
            {
                Tabella = table,
                Messaggio = JsonSerializer.Serialize(opMsg)
            };
        }
    }
}
