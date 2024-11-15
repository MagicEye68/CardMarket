using Annunci.Repository.Abstractions;
using Annunci.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Annunci.Repository
{
    public class Repository : IRepository
    {
        private AnnunciDbContext _annunciDbContext;
        public Repository(AnnunciDbContext AccountManagerDbContext)
        {
            _annunciDbContext = AccountManagerDbContext;
        }
        public async Task AddCarta(Carta carta, CancellationToken cancellationToken = default)
        {
            await _annunciDbContext.Carte.AddAsync(carta, cancellationToken);
        }

        public async Task<Inserzione> AddInserzione(Inserzione inserzione, CancellationToken cancellationToken = default)
        {
            await _annunciDbContext.Inserzioni.AddAsync(inserzione, cancellationToken);

            return inserzione;
        }

        public async Task AddRarita(TipoRarita rarita, CancellationToken cancellationToken = default)
        {
            await _annunciDbContext.Rarita.AddAsync(rarita, cancellationToken);
        }

        public async Task AddUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            await _annunciDbContext.Utenti.AddAsync(utente, cancellationToken);
        }

        public void DeleteCarta(Carta carta)
        {
                _annunciDbContext.Carte.Remove(carta);     
        }

        public  void  DeleteInserzione(Inserzione inserzione)
        {
                _annunciDbContext.Inserzioni.Remove(inserzione);
        }

        public void DeleteRarita(TipoRarita rarita)
        {
            _annunciDbContext.Rarita.Remove(rarita);
       
        }

        public void DeleteUtente(Utente utente)
        {
            _annunciDbContext.Utenti.Remove(utente);
        }

        public async Task<List<Inserzione>> GetInserzioneByCarta(Carta carta, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Inserzioni.Where(i => i.Carta.Equals(carta.Id)).ToListAsync();
        }

        public async Task<List<Inserzione>> GetInserzioneByCartaRarita(Carta carta, TipoRarita rarita, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Inserzioni.Where(i => i.Carta.Equals(carta.Id) && i.Rarita.Equals(rarita.Rarita)).ToListAsync();
        }

        public async Task<List<Inserzione>> GetInserzioneByUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Inserzioni.Where(i => i.Venditore.Equals(utente.Id)).ToListAsync();
        }

        public async Task<Carta?> ReadCarta(string Id, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Carte.Where(c => c.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Inserzione?> ReadInserzione(int Id, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Inserzioni.Where(i => i.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TipoRarita?> ReadRarita(string Rarita, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Rarita.Where(r => r.Rarita == Rarita).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Utenti.Where(u => u.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }
        public void UpdateQuantitaInserzione(Inserzione i, int nuovaQuantita, CancellationToken cancellationToken = default)
        {
            i.Quantita = nuovaQuantita;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Carta>> GetCartaByStringa(string stringa,CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Carte.Where(c => c.Nome.Contains(stringa)).ToListAsync();
        }

        public async Task<List<Inserzione>> GetInserzioneByCartaRaritaVenditore(Carta carta, TipoRarita rarita, Utente utente, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Inserzioni.Where(i => i.Venditore.Equals(utente.Id) && i.Carta.Equals(carta.Id) && i.Rarita.Equals(rarita.Rarita)).ToListAsync();
        }
        public async Task<List<TipoRarita>> GetRarita(CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.Rarita.ToListAsync();
        }

        public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);
        }

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default)
        {
            return await _annunciDbContext.TransactionalOutboxList.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default)
        {
            _annunciDbContext.TransactionalOutboxList.Remove(
                (await GetTransactionalOutboxByKey(id, cancellationToken)) ??
                throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));
        }

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default)
        {
            await _annunciDbContext.TransactionalOutboxList.AddAsync(transactionalOutbox);
        }
    }
}
