using System.Text.Json;
using Transazioni.Repository.Model;
using Transazioni.Shared;
using Utility.Kafka.Constants;
using Utility.Kafka.Messages;

namespace Transazioni.Business.Factory
{
    public class TransactionalOutboxFactory
    {
      
            public static TransactionalOutbox CreateAddPagamento(PagamentoReadDto dto) => Create(dto, Operations.Insert);

            private static TransactionalOutbox Create(PagamentoReadDto dto, string operation) => Create(nameof(Pagamento), dto, operation);


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

