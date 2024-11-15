using Recensioni.Business.Abstractions;
using Recensioni.Repository.Abstractions;
using Recensioni.Repository.Model;
using Recensioni.Shared;
using Microsoft.Extensions.Logging;




namespace Recensioni.Business
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
                Compratore = pagamento.Compratore
            };

            await _repository.AddPagamento(add, cancellationToken);
            await _repository.SaveChangesAsync();
        }

        public async Task AddRecensione(RecensioneDto recensione, string loggedUserId, CancellationToken cancellationToken = default)
        {
            
            Pagamento? pagamento = await _repository.ReadPagamento(recensione.Pagamento);
            if (pagamento == null || pagamento == default(Pagamento))
            {
                throw new InvalidDataException("Pagamento non trovato");
            }

            if(!(pagamento.Compratore.Equals(loggedUserId))) 
            {
                throw new InvalidDataException("Pagamento non a tuo nome");
            }
            Recensione? r = await _repository.GetRecensioneFromPagamento(pagamento);

            if (!(r == null || r == default(Recensione)))
            {
                throw new InvalidDataException("Recensione gia presente");
            }
            if (recensione.Voto <= 0 || recensione.Voto > 5)
            {
                throw new InvalidDataException("Voto non valido ( <= 0 || > 5 )");
            }
            if (recensione.Testo == "")
            {
                throw new InvalidDataException("Testo vuoto");
            }
            Recensione add = new Recensione
            {
                Testo = recensione.Testo,
                Voto = recensione.Voto,
                Pagamento = recensione.Pagamento
            };

            await _repository.AddRecensione(add, cancellationToken);
            await _repository.SaveChangesAsync();
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

        public async Task<List<RecensioneReadDto>> GetRecensioneByUtente(string id, CancellationToken cancellationToken = default)
        {
            Utente? utente = await _repository.ReadUtente(id);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Recensione non trovata");
            }
            List<Recensione> recensioni = await _repository.GetRecensioneByUtente(utente, cancellationToken);
            return GetRecensioneDtoFromModel(recensioni);
        }

        public async Task<List<RecensioneReadDto>> GetRecensioneByVenditore(string id, CancellationToken cancellationToken = default)
        {
            Utente? utente = await _repository.ReadUtente(id);
            if (utente == null || utente == default(Utente))
            {
                throw new InvalidDataException("Recensione non trovata");
            }
            List<Recensione> recensioni = await _repository.GetRecensioneByVenditore(utente, cancellationToken);
            return GetRecensioneDtoFromModel(recensioni);
        }



        public async Task RemoveRecensione(int idRecensione, CancellationToken cancellationToken = default)
        {
            Recensione? recensione = await _repository.ReadRecensione(idRecensione);
            if (recensione == null || recensione == default(Recensione))
            {
                throw new InvalidDataException("Recensione non trovata");
            }
            _repository.DeleteRecensione(recensione);

            await _repository.SaveChangesAsync(cancellationToken);
        }
        public async Task<Dictionary<string, double>> GetMediaVenditori(double treshold, CancellationToken cancellationToken = default)
            
        {   
            List<Recensione> recensioni = await _repository.GetRecensioni();
            Dictionary<string, List<Recensione>> map = new Dictionary<string, List<Recensione>>();
            foreach(Recensione r in recensioni)
            {
                if (!(map.ContainsKey(r.Pagamentofk.Annunciofk.Venditore)))
                {
                    map.Add(r.Pagamentofk.Annunciofk.Venditore, new List<Recensione>());
                }

                map[r.Pagamentofk.Annunciofk.Venditore].Add(r);   
            }

            Dictionary<string, double> map2 = new Dictionary<string, double>();
            foreach (KeyValuePair<string, List<Recensione>> entry in map)
            {
                double media = 0;
                foreach (Recensione r in entry.Value)
                {
                    media += r.Voto;
                }
                media/=entry.Value.Count;
                if(media >= treshold)
                {
                    map2.Add(entry.Key, media);
                }
            }
            return map2;
        }



        private List<RecensioneReadDto> GetRecensioneDtoFromModel(List<Recensione> recensioni)
        {
            List<RecensioneReadDto> result = new List<RecensioneReadDto>();
            foreach (Recensione r in recensioni)
            {
                RecensioneReadDto tmp = new RecensioneReadDto
                {
                    Id = r.Id,
                    Testo = r.Testo,
                    Voto = r.Voto,
                    Pagamento = r.Pagamento

                 };
                result.Add(tmp);
            }
            return result;
        }

        


    }
}
