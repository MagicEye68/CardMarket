using Transazioni.Repository.Model;

namespace Transazioni.Repository.Abstractions
{
    public interface IRepository
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task AddAnnuncio(Annuncio annuncio, CancellationToken cancellationToken = default);    
        public void DeleteAnnuncio(Annuncio annuncio);      
        public Task<Annuncio?> ReadAnnuncio(int Id, CancellationToken cancellationToken = default);
        public Task<Pagamento> AddPagamento(Pagamento pagamento, CancellationToken cancellationToken = default);
        public Task<Pagamento?> ReadPagamento(int Id, CancellationToken cancellationToken = default);
        public Task AddUtente(Utente utente, CancellationToken cancellationToken = default);
        public Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default);
        public  Task<List<Pagamento>> GetPagamentoFromUtente(Utente utente, CancellationToken cancellationToken = default);
        public  Task<List<Pagamento>> GetPagamentoFromMetodo(string metodo, CancellationToken cancellationToken = default);
        public  Task<List<Pagamento>> GetPagamentiFromAnnuncio(int idAnnuncio, CancellationToken cancellationToken = default);
        public  Task<List<Pagamento>> GetPagamentoFromStato(string stato, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);
        public Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
        public Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
        public Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);

    }
}
