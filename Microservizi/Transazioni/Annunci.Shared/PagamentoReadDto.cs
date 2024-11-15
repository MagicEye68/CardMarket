

namespace Transazioni.Shared
{
    public class PagamentoReadDto
    {
        public int Id { get; set; }
        public int Annuncio { get; set; }
        public string Compratore { get; set; }
        public string Metodo { get; set; }
        public string Stato { get; set; }
        public PagamentoReadDto() { }

        public PagamentoReadDto(int id, int annuncio, string compratore, string metodo, string stato)
        {
            Id = id;
            Annuncio = annuncio;
            Compratore = compratore;
            Metodo = metodo;
            Stato = stato;
        }
    }

}
