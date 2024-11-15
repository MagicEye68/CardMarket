

namespace Transazioni.Shared
{
    public class AnnuncioKafkaDto
    {
        public int Id { get; set; }
        public string Venditore { get; set; }
        public string Carta { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Rarita { get; set; }
    }
}
