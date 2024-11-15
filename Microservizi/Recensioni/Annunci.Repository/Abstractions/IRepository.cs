using Recensioni.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository.Abstractions
{
    public interface IRepository
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task AddAnnuncio(Annuncio annuncio, CancellationToken cancellationToken = default);
        
        public void DeleteAnnuncio(Annuncio annuncio);
       
        public Task<Annuncio?> ReadAnnuncio(int Id, CancellationToken cancellationToken = default);

        public Task AddPagamento(Pagamento pagamento, CancellationToken cancellationToken = default);

        public Task<Pagamento?> ReadPagamento(int Id, CancellationToken cancellationToken = default);

        public Task AddRecensione(Recensione recensione, CancellationToken cancellationToken = default);

        public void DeleteRecensione(Recensione recensione);

        public Task<Recensione?> ReadRecensione(int Id, CancellationToken cancellationToken = default);
        public Task AddUtente(Utente utente, CancellationToken cancellationToken = default);


        public Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default);

        public Task<List<Recensione>> GetRecensioneByUtente(Utente utente, CancellationToken cancellationToken = default);

        public  Task<List<Recensione>> GetRecensioneByVenditore(Utente utente, CancellationToken cancellationToken = default);
        public Task<List<Recensione>> GetRecensioni(CancellationToken cancellationToken = default);

        public Task<Recensione?> GetRecensioneFromPagamento(Pagamento pagamento, CancellationToken cancellationToken = default);
    }
}
