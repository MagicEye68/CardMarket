using Autenticazione.Repository.Abstractions;
using Autenticazione.Repository.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Autenticazione.Repository
{
    public class Repository : IRepository
    {
        private readonly AutenticazioneDbContext _autenticazioneDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Repository(AutenticazioneDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _autenticazioneDbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task GiveRoleAsync(string id, string role, CancellationToken cancellationToken = default)
        {
            IdentityUser? user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new ArgumentException("Non trovo lo user: " + id);

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            if (!await _userManager.IsInRoleAsync(user, role))
                await _userManager.AddToRoleAsync(user, role);
        }



        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _autenticazioneDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateTransaction(Func<CancellationToken, Task> action, CancellationToken cancellationToken = default)
        {
            if (_autenticazioneDbContext.Database.CurrentTransaction != null)
            {
                await action(cancellationToken);
            }
            else
            {
                using IDbContextTransaction transaction = await _autenticazioneDbContext.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    await action(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                }
                catch
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default)
        {
            return await _autenticazioneDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);
        }

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default)
        {
            return await _autenticazioneDbContext.TransactionalOutboxList.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default)
       {
            _autenticazioneDbContext.TransactionalOutboxList.Remove(
                (await GetTransactionalOutboxByKey(id, cancellationToken)) ??
                throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));
        }

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default)
        {
            await _autenticazioneDbContext.TransactionalOutboxList.AddAsync(transactionalOutbox);
        }
    }
}
