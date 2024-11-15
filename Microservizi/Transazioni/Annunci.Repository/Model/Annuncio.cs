

namespace Transazioni.Repository.Model
{
    public class Annuncio
    {
        public int Id { get; set; }
        public string Venditore { get; set; }
        public Utente Venditorefk { get; set; }
        public ICollection<Pagamento> Pagamenti { get; set; } = new List<Pagamento>();

    }
}
