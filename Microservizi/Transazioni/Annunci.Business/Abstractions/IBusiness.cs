using Transazioni.Shared;

namespace Transazioni.Business.Abstractions
{
    public interface IBusiness
    {   
        public Task AddAnnuncio(AnnuncioDto annuncio, CancellationToken cancellationToken = default);
        public Task AddPagamento(PagamentoDto pagamento, CancellationToken cancellationToken = default);
        public Task AddUtente(UtenteDto utente, CancellationToken cancellationToken = default);
        public  Task<List<PagamentoReadDto>> GetPagamentoFromUtente(string id, CancellationToken cancellationToken = default);
        public  Task<List<PagamentoReadDto>> GetPagamentoFromMetodo(string metodo, CancellationToken cancellationToken = default);
        public  Task<List<PagamentoReadDto>> GetPagamentoFromStato(string stato, CancellationToken cancellationToken = default);
    }
}
