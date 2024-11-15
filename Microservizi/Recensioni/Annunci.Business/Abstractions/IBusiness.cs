using Recensioni.Repository.Model;
using Recensioni.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Business.Abstractions
{
    public interface IBusiness
    {   
        public Task<List<RecensioneReadDto>> GetRecensioneByUtente(string id, CancellationToken cancellationToken = default);
        public Task AddAnnuncio(AnnuncioDto annuncio, CancellationToken cancellationToken = default);
        public Task AddPagamento(PagamentoDto pagamento, CancellationToken cancellationToken = default);
        public Task AddRecensione(RecensioneDto recensione, string loggedUserId, CancellationToken cancellationToken = default);
        public Task AddUtente(UtenteDto utente, CancellationToken cancellationToken = default);
        public Task RemoveRecensione(int idRecensione, CancellationToken cancellationToken = default);
        public Task<List<RecensioneReadDto>> GetRecensioneByVenditore(string id, CancellationToken cancellationToken = default);
        public Task<Dictionary<string, double>> GetMediaVenditori(double treshold, CancellationToken cancellationToken = default);
    }
}
