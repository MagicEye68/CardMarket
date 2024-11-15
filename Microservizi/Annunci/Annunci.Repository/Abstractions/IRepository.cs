using Annunci.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository.Abstractions
{
    public interface IRepository
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task AddCarta(Carta carta, CancellationToken cancellationToken = default);
        
        public void DeleteCarta(Carta carta);
       
        public Task<Carta?> ReadCarta(string Id, CancellationToken cancellationToken = default);

        public Task<Inserzione> AddInserzione(Inserzione inserzione, CancellationToken cancellationToken = default);

        public void DeleteInserzione(Inserzione inserzione);

        public Task<Inserzione?> ReadInserzione(int Id, CancellationToken cancellationToken = default);

        public Task AddRarita(TipoRarita rarita, CancellationToken cancellationToken = default);

        public void DeleteRarita(TipoRarita rarita);

        public Task<TipoRarita?> ReadRarita(string Rarita, CancellationToken cancellationToken = default);
        public Task AddUtente(Utente utente, CancellationToken cancellationToken = default);

        public void DeleteUtente(Utente utente);

        public Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default);
        public Task<List<TipoRarita>> GetRarita(CancellationToken cancellationToken = default);

        public Task<List<Inserzione>> GetInserzioneByCarta(Carta carta, CancellationToken cancellationToken = default);
        public Task<List<Inserzione>> GetInserzioneByCartaRarita(Carta carta,TipoRarita rarita, CancellationToken cancellationToken = default);
        public Task<List<Carta>> GetCartaByStringa(String stringa, CancellationToken cancellationToken = default);
        public Task<List<Inserzione>> GetInserzioneByCartaRaritaVenditore(Carta carta, TipoRarita rarita,Utente utente, CancellationToken cancellationToken = default);
        public Task<List<Inserzione>> GetInserzioneByUtente(Utente utente, CancellationToken cancellationToken = default);
        public void UpdateQuantitaInserzione(Inserzione i, int nuovaQuantita, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);
        public Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
        public Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
        public Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);


    }
}
