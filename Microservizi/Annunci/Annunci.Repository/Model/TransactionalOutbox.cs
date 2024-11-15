using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository.Model
{
    public class TransactionalOutbox
    {
        public int Id { get; set; }
        public string Tabella { get; set; } = string.Empty;
        public string Messaggio { get; set; } = string.Empty;
    }
}
