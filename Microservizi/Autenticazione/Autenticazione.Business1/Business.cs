using Autenticazione.Business.Abstractions;
using Autenticazione.Business.Factory;
using Autenticazione.Repository;
using Autenticazione.Repository.Abstractions;
using Autenticazione.Shared;
namespace Autenticazione.Business
{
    public class Business : IBusiness
    {

        private readonly IRepository repository;
        public Business(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task GiveAdminRole(string username, CancellationToken cancellationToken = default)
        {
            await repository.GiveRoleAsync(username, "Admin", cancellationToken);

            await repository.SaveChangesAsync(cancellationToken);
        }

        public async Task AddUser(UserDto user, CancellationToken cancellationToken = default)
        {
                await repository.InsertTransactionalOutbox(TransactionalOutboxFactory.CreateAddUser(user), cancellationToken);
                await repository.SaveChangesAsync(cancellationToken);
            
        }
    }
}