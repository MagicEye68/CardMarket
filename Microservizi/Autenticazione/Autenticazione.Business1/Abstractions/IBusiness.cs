using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticazione.Shared;

namespace Autenticazione.Business.Abstractions
{
    public interface IBusiness
    {

        public Task GiveAdminRole(string username, CancellationToken cancellationToken = default);
        public Task AddUser(UserDto user, CancellationToken cancellationToken = default);

    }
}
