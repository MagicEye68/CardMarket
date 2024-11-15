using Transazioni.Repository.Abstractions;
using Transazioni.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Transazioni.Repository
{
    public class Repository : IRepository
    {
        private TransazioniDbContext _transazioniDbContext;
        public Repository(TransazioniDbContext AccountManagerDbContext)
        {
            _transazioniDbContext = AccountManagerDbContext;
        }

        public async Task AddAnnuncio(Annuncio annuncio, CancellationToken cancellationToken = default)
        {
            await _transazioniDbContext.Annunci.AddAsync(annuncio, cancellationToken);
        }

        public async Task<Pagamento> AddPagamento(Pagamento pagamento, CancellationToken cancellationToken = default)
        {
            await _transazioniDbContext.Pagamenti.AddAsync(pagamento, cancellationToken);

            return pagamento;
        }

        public async Task AddUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            await _transazioniDbContext.Utente.AddAsync(utente, cancellationToken);
        }

        public void DeleteAnnuncio(Annuncio annuncio)
        {
            _transazioniDbContext.Annunci.Remove(annuncio);
        }

        public async Task<Annuncio?> ReadAnnuncio(int Id, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Annunci.Where(a => a.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Pagamento?> ReadPagamento(int Id, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Pagamenti.Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Utente.Where(u => u.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Pagamento>> GetPagamentoFromUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Pagamenti.Where(p => p.Compratore.Equals(utente.Id)).ToListAsync();
        }
        public async Task<List<Pagamento>> GetPagamentoFromMetodo(string metodo, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Pagamenti.Where(p => p.Metodo.Equals(metodo)).ToListAsync();
        }

        public async Task<List<Pagamento>> GetPagamentiFromAnnuncio(int idAnnuncio, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Pagamenti.Where(p => p.Annuncio.Equals(idAnnuncio)).ToListAsync();
        }

        public async Task<List<Pagamento>> GetPagamentoFromStato(string stato, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.Pagamenti.Where(p => p.Stato.Equals(stato)).ToListAsync();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);
        }

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default)
        {
            return await _transazioniDbContext.TransactionalOutboxList.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default)
        {
            _transazioniDbContext.TransactionalOutboxList.Remove(
                (await GetTransactionalOutboxByKey(id, cancellationToken)) ??
                throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));
        }

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default)
        {
            await _transazioniDbContext.TransactionalOutboxList.AddAsync(transactionalOutbox);
        }

    }
}
