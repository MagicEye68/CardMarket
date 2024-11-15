using Annunci.Repository.Model;
using Annunci.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Business.Abstractions
{
    public interface IBusiness
    {   
        public Task<List<InserzioneReadDto>> GetInserzioniByUtente(string id, CancellationToken cancellationToken = default);
        public Task<List<InserzioneReadDto>> GetInserzioniByCarta(string idCarta, CancellationToken cancellationToken = default);
        public Task<List<InserzioneReadDto>> GetInserzioniByCartaRarita(string idCarta, string Rarita, CancellationToken cancellationToken = default);
        public  Task<List<CartaDto>> GetCartaByStringa(string stringa, CancellationToken cancellationToken = default);
        public Task AddInserzione(InserzioneDto inserzione, CancellationToken cancellationToken = default);
        public Task AddCarta(CartaDto carta, CancellationToken cancellationToken = default);
        public Task AddRarita(TipoRaritaDto rarita, CancellationToken cancellationToken = default);
        public Task AddUtente(UtenteDto utente, CancellationToken cancellationToken = default);
        public Task RemoveInserzione(int idInserzione,int quantita, CancellationToken cancellationToken = default);
        public  Task<List<string>> GetRarita(CancellationToken cancellationToken = default);
    }
}
