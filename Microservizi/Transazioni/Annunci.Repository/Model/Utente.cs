

namespace Transazioni.Repository.Model
{
    public class Utente
    {
        public string Id { get; set; }
        public ICollection<Annuncio> Annunci { get; set; } = new List<Annuncio>();
        public ICollection<Pagamento> Pagamenti { get; set; } = new List<Pagamento>();
    }
}
