using Transazioni.Business.Abstractions;
using Transazioni.Repository.Abstractions;
using Transazioni.Repository.Model;
using Transazioni.Shared;
using Microsoft.Extensions.Logging;
using Transazioni.Business.Factory;

namespace Transazioni.Business
{
    public class Business : IBusiness
    {
        private readonly IRepository _repository;
        private readonly ILogger<Business> _logger;
        public Business(IRepository repository, ILogger<Business> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task AddAnnuncio(AnnuncioDto annuncio, CancellationToken cancellationToken = default)
        {
            Utente? utente = await _repository.ReadUtente(annuncio.Venditore);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Utente non trovato");
            }
            Annuncio add = new Annuncio
            {        
                Venditore = annuncio.Venditore
            };

            await _repository.AddAnnuncio(add, cancellationToken);
            await _repository.SaveChangesAsync();
        }

        public async Task AddPagamento(PagamentoDto pagamento, CancellationToken cancellationToken = default)
        {
            Annuncio? annuncio = await _repository.ReadAnnuncio(pagamento.Annuncio);
            if (annuncio == null || annuncio == default(Annuncio))
            {
                throw new InvalidDataException("Annuncio non trovato");
            }
            Utente? utente = await _repository.ReadUtente(pagamento.Compratore);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Utente non trovato");
            }

            Pagamento add = new Pagamento
            {
                Annuncio = pagamento.Annuncio,
                Compratore = pagamento.Compratore,
                Metodo = pagamento.Metodo,
                Stato = pagamento.Stato
            };

            Pagamento nuova = await _repository.AddPagamento(add, cancellationToken);
            await _repository.SaveChangesAsync();

            if(pagamento.Stato.Equals("accettato") || pagamento.Stato.Equals("Accettato"))
            {
                PagamentoReadDto nuovopagamento = new PagamentoReadDto(nuova.Id, nuova.Annuncio, nuova.Compratore, nuova.Metodo, nuova.Stato);
                await _repository.InsertTransactionalOutbox(TransactionalOutboxFactory.CreateAddPagamento(nuovopagamento), cancellationToken);
                await _repository.SaveChangesAsync();
            }

        }


        public async Task AddUtente(UtenteDto utente, CancellationToken cancellationToken = default)
        {
            Utente? utenteletto = await _repository.ReadUtente(utente.Id);
            if (!(utenteletto == null || utenteletto == default(Utente)))
            {
                throw new InvalidDataException("Utente gia presente");
            }

            Utente add = new Utente
            {
                Id = utente.Id,
            };

            await _repository.AddUtente(add, cancellationToken);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<PagamentoReadDto>> GetPagamentoFromUtente(string id, CancellationToken cancellationToken = default)
        {
            Utente? utente = await _repository.ReadUtente(id);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Recensione non trovata");
            }
            List<Pagamento> pagamenti = await _repository.GetPagamentoFromUtente(utente, cancellationToken);
            return GetPagamentoDtoFromModel(pagamenti);
        }

        public async Task<List<PagamentoReadDto>> GetPagamentoFromMetodo(string metodo, CancellationToken cancellationToken = default)
        {
            List<Pagamento> pagamenti = await _repository.GetPagamentoFromMetodo(metodo, cancellationToken);
            return GetPagamentoDtoFromModel(pagamenti);
        }

        public async Task<List<PagamentoReadDto>> GetPagamentoFromStato(string stato, CancellationToken cancellationToken = default)
        {
            List<Pagamento> pagamenti = await _repository.GetPagamentoFromStato(stato, cancellationToken);
            return GetPagamentoDtoFromModel(pagamenti);
        }
        private List<PagamentoReadDto> GetPagamentoDtoFromModel(List<Pagamento> pagamenti)
        {
            List<PagamentoReadDto> result = new List<PagamentoReadDto>();
            foreach (Pagamento p in pagamenti)
            {
                PagamentoReadDto tmp = new PagamentoReadDto
                {
                    Id = p.Id,
                    Annuncio = p.Annuncio,
                    Compratore = p.Compratore,
                    Metodo = p.Metodo,
                    Stato = p.Stato

                };
                result.Add(tmp);
            }
            return result;
        }

    }
}
