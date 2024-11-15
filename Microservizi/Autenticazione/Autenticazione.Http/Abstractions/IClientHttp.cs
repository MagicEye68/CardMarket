using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticazione.Http.Abstractions
{
    public interface IClientHttp
    {
        public Task<HttpResponseMessage> IsAdmin(CancellationToken cancellationToken = default);

        public Task<HttpResponseMessage> GetUserID(CancellationToken cancellationToken = default);
    }
}
