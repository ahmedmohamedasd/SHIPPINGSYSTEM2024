using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRoleManagerService
    {
        List<IRole> All();
        IRole Get(string id);
        Task<IList<Claim>> GetClaimsAsync(IRole role);
        Task UpdateRole(string id, IList<string> claims);
        Task<IdentityResult> CreateRole(string name);
        Task<bool> IsRoleExists(string name, string id = null);
        Task UpdateRoleName(string id, string name);
        Task Delete(string id);
        Task<IRole> FindByNameAsync(string r);
    }
}
