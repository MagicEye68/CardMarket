using Autenticazione.Repository.Model;
using Autenticazione.Shared;
using System.Text.Json;
using Utility.Kafka.Constants;
using Utility.Kafka.Messages;

namespace Autenticazione.Business.Factory
{
    public class TransactionalOutboxFactory
    {
        public static TransactionalOutbox CreateAddUser(UserDto dto) => Create(dto, Operations.Insert);

        private static TransactionalOutbox Create(UserDto dto, string operation) => Create(nameof(AspNetUsers), dto, operation);

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
