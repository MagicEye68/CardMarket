using Recensioni.Repository.Abstractions;
using Recensioni.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Recensioni.Repository
{
    public class Repository : IRepository
    {
        private RecensioniDbContext _recensioniDbContext;
        public Repository(RecensioniDbContext AccountManagerDbContext)
        {
            _recensioniDbContext = AccountManagerDbContext;
        }

        public async Task AddAnnuncio(Annuncio annuncio, CancellationToken cancellationToken = default)
        {
            await _recensioniDbContext.Annunci.AddAsync(annuncio, cancellationToken);
        }

        public async Task AddPagamento(Pagamento pagamento, CancellationToken cancellationToken = default)
        {
            await _recensioniDbContext.Pagamenti.AddAsync(pagamento, cancellationToken);
        }

        public async Task AddRecensione(Recensione recensione, CancellationToken cancellationToken = default)
        {
            await _recensioniDbContext.Recensione.AddAsync(recensione, cancellationToken);
        }

        public async Task AddUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            await _recensioniDbContext.Utente.AddAsync(utente, cancellationToken);
        }

        public void DeleteAnnuncio(Annuncio annuncio)
        {
            _recensioniDbContext.Annunci.Remove(annuncio);
        }


        public void DeleteRecensione(Recensione recensione)
        {
            _recensioniDbContext.Recensione.Remove(recensione);
        }


        public async Task<List<Recensione>> GetRecensioneByUtente(Utente utente, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Recensione.Include(r => r.Pagamentofk).Where(r => r.Pagamentofk.Compratore.Equals(utente.Id)).ToListAsync();
        }

        public async Task<Annuncio?> ReadAnnuncio(int Id, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Annunci.Where(a => a.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Pagamento?> ReadPagamento(int Id, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Pagamenti.Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Recensione?> ReadRecensione(int Id, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Recensione.Where(r => r.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Utente?> ReadUtente(string Id, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Utente.Where(u => u.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Recensione>> GetRecensioneByVenditore(Utente utente, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Recensione.Include(r => r.Pagamentofk).Include(a => a.Pagamentofk.Annunciofk).Where(r => r.Pagamentofk.Annunciofk.Venditore.Equals(utente.Id)).ToListAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Recensione?> GetRecensioneFromPagamento(Pagamento pagamento, CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Recensione.Where(r=> r.Pagamento == pagamento.Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Recensione>> GetRecensioni(CancellationToken cancellationToken = default)
        {
            return await _recensioniDbContext.Recensione.Include(r => r.Pagamentofk.Annunciofk.Venditorefk).ToListAsync();
        }
    }
}
