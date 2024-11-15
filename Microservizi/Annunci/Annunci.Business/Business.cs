using Annunci.Business.Abstractions;
using Annunci.Business.Factory;
using Annunci.Repository.Abstractions;
using Annunci.Repository.Model;
using Annunci.Shared;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata.Ecma335;

namespace Annunci.Business
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
        public async Task AddCarta(CartaDto carta, CancellationToken cancellationToken = default)
        {
            Carta? cartaletta = await _repository.ReadCarta(carta.Id);
            if(!(cartaletta == null || cartaletta == default(Carta))) 
            {
                throw new InvalidDataException("Carta gia presente");
            }

            Carta add = new Carta
            {
                Id = carta.Id,
                Nome = carta.Nome
            };

            await _repository.AddCarta(add, cancellationToken);
            await _repository.SaveChangesAsync();
            
        }

        public async Task AddInserzione(InserzioneDto inserzione, CancellationToken cancellationToken = default)
        {
            Carta? carta = await _repository.ReadCarta(inserzione.Carta);
            if (carta == null || carta == default(Carta))
            {
                throw new InvalidDataException("Carta non trovata");
            }

            TipoRarita? rarita = await _repository.ReadRarita(inserzione.Rarita);
            if (rarita == null || carta == default(Carta))
            {
                throw new InvalidDataException("Rarita non trovata");
            }
            Utente? utente = await _repository.ReadUtente(inserzione.Venditore);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Utente non trovato");
            }
            if(inserzione.Quantita < 1)
            {
                throw new InvalidDataException("Quantita' minore di 1");
            }

            if(inserzione.Prezzo < 0)
            {
                throw new InvalidDataException("Prezzo < 0");
            }
            List<Inserzione> inserzioni = await _repository.GetInserzioneByCartaRaritaVenditore(carta,rarita,utente,cancellationToken);
            if(inserzioni.Count !=0)
            {
                Inserzione i = inserzioni.ElementAt(0);
                _repository.UpdateQuantitaInserzione(i,i.Quantita+inserzione.Quantita);
                await _repository.SaveChangesAsync();
                return ;
            }
            Inserzione add = new Inserzione
            {
                Id = inserzione.Id,
                Venditore = inserzione.Venditore,
                Carta = inserzione.Carta,
                Quantita = inserzione.Quantita,
                Prezzo = inserzione.Prezzo,
                Rarita = inserzione.Rarita
            };



            Inserzione nuova = await _repository.AddInserzione(add, cancellationToken);
            await _repository.SaveChangesAsync();
            InserzioneDto nuovainserzione = new InserzioneDto(nuova.Id,nuova.Venditore, nuova.Carta, nuova.Quantita, nuova.Prezzo, nuova.Rarita);
        
            await _repository.InsertTransactionalOutbox(TransactionalOutboxFactory.CreateAddAnnuncio(nuovainserzione),cancellationToken);
            await _repository.SaveChangesAsync();
        }

        public async Task AddRarita(TipoRaritaDto rarita, CancellationToken cancellationToken = default)
        {
            TipoRarita? raritaletta = await _repository.ReadRarita(rarita.Rarita);
            if (!(raritaletta == null || raritaletta == default(TipoRarita)))
            {
                throw new InvalidDataException("Rarita gia presente");
            }
            TipoRarita add = new TipoRarita
            {
                  Rarita = rarita.Rarita
            };

            await _repository.AddRarita(add, cancellationToken);
            await _repository.SaveChangesAsync();
        }

        public async Task AddUtente(UtenteDto utente, CancellationToken cancellationToken = default)
        {
            Utente? utenteletto = await _repository.ReadUtente(utente.Id);
            if (!(utenteletto == null || utenteletto == default(Utente)))
            {
                throw new InvalidDataException("Carta gia presente");
            }
            Utente add = new Utente
            {
                Username = utente.Username,
               Id = utente.Id
            };

            await _repository.AddUtente(add, cancellationToken);
            await _repository.SaveChangesAsync();

    }

        public async Task RemoveInserzione(int idInserzione, int quantita, CancellationToken cancellationToken = default)
        {
            Inserzione? inserzione = await _repository.ReadInserzione(idInserzione);
            if (inserzione == null || inserzione == default(Inserzione))
            {
                throw new InvalidDataException("Inserzione non trovata");
            }
            if ( quantita > inserzione.Quantita )
            {
                throw new ArgumentException("Impossibile rimuovente piu quantita di quante presenti");
            }
            if (quantita == inserzione.Quantita)
            {
                 _repository.DeleteInserzione(inserzione);
            }
            else
            {
                 _repository.UpdateQuantitaInserzione(inserzione, inserzione.Quantita-quantita, cancellationToken);
            }
       
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<InserzioneReadDto>> GetInserzioniByCarta(string idCarta, CancellationToken cancellationToken = default)
        {
            Carta? carta = await _repository.ReadCarta(idCarta);
            if(carta == null || carta == default(Carta))
            {
                throw new InvalidDataException("Carta non trovata");
            }
            List<Inserzione> inserzioni = await _repository.GetInserzioneByCarta(carta, cancellationToken);
            return GetInserzioneDtoFromModel(inserzioni);

        }

        public async Task<List<InserzioneReadDto>> GetInserzioniByCartaRarita(string idCarta, string Rarita, CancellationToken cancellationToken = default)
        {
            Carta? carta = await _repository.ReadCarta(idCarta);
            if (carta == null || carta == default(Carta))
            {
                throw new InvalidDataException("Carta non trovata");
            }

            TipoRarita? rarita = await _repository.ReadRarita(Rarita);
            if (rarita == null || carta == default(Carta))
            {
                throw new InvalidDataException("Rarita non trovata");
            }
            List<Inserzione> inserzioni = await _repository.GetInserzioneByCartaRarita(carta,rarita, cancellationToken);
            return GetInserzioneDtoFromModel(inserzioni);
        }

        public async Task<List<InserzioneReadDto>> GetInserzioniByUtente(string id, CancellationToken cancellationToken = default)
        {
            Utente? utente = await _repository.ReadUtente(id);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Utente non trovato");
            }
            List<Inserzione> inserzioni = await _repository.GetInserzioneByUtente(utente, cancellationToken);
            return GetInserzioneDtoFromModel(inserzioni);

        }

        public async Task<List<CartaDto>> GetCartaByStringa(string stringa, CancellationToken cancellationToken = default)
        {
            List<Carta> carte = await _repository.GetCartaByStringa(stringa, cancellationToken);
            return GetCarteDtoFromModel(carte);

        }
        public async Task<List<string>> GetRarita(CancellationToken cancellationToken = default)
        {
            List<TipoRarita> rarita = await _repository.GetRarita(cancellationToken);
            List<string> result = new List<string>();
            foreach(TipoRarita r in rarita)
            {
                result.Add(r.Rarita);
            }
            return result;

        }

        private List<InserzioneReadDto> GetInserzioneDtoFromModel(List<Inserzione> inserzioni)
        {
            List<InserzioneReadDto> result = new List<InserzioneReadDto>();
            foreach (Inserzione i in inserzioni)
            {
                InserzioneReadDto tmp = new InserzioneReadDto
                {
                    Id = i.Id,
                    Venditore = i.Venditore,
                    Carta = i.Carta,
                    Quantita = i.Quantita,
                    Prezzo = i.Prezzo,
                    Rarita = i.Rarita

                };
                result.Add(tmp);
            }
            return result;
        }

        private List<CartaDto> GetCarteDtoFromModel(List<Carta> carte)
        {
            List<CartaDto> result = new List<CartaDto>();
            foreach (Carta c in carte)
            {
                CartaDto tmp = new CartaDto
                {
                    Id = c.Id,
                    Nome = c.Nome,

                };
                result.Add(tmp);
            }
            return result;
        }

    }
}
