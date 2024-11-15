using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticazione.Repository.Model {
    public class TransactionalOutbox {
        public int Id { get; set; }
        public string Tabella { get; set; } = string.Empty;
        public string Messaggio { get; set; } = string.Empty;
    }
}
