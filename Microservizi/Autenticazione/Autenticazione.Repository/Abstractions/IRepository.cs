using Autenticazione.Repository.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticazione.Repository.Abstractions
{
    public interface IRepository
    {

        public  Task GiveRoleAsync(string email, string role, CancellationToken cancellationToken = default);

        public  Task SaveChangesAsync(CancellationToken cancellationToken = default);


        public  Task CreateTransaction(Func<CancellationToken, Task> action, CancellationToken cancellationToken = default);



        public  Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);



        public  Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);



        public  Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);



        public  Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);
        
    }
}
