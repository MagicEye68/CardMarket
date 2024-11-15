namespace Transazioni.Repository.Model
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int Annuncio { get; set; }
        public string Compratore { get; set; }
        public string Metodo { get; set; }
        public string Stato { get; set; }
        public Annuncio Annunciofk { get; set; }
        public Utente Compratorefk { get; set; }
    }
}
