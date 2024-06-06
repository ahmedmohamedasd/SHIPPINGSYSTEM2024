using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserManagerService
    {
        Task<IList<Claim>> GetClaimsAsync(IAppUser appUser);
    }
}
