using Application.Interface;
using Infrastructure.Persistence.model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAppDbContext _appDbContext;
        public UserManagerService(UserManager<AppUser> userManager, RoleManager<Role> roleManager, IAppDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }

        public async Task<IList<Claim>> GetClaimsAsync(IAppUser appUser)
        {
           var result =new List<Claim>();
            var userClaims = await _userManager.GetClaimsAsync((AppUser)appUser);
            var roles = await _userManager.GetRolesAsync((AppUser)appUser);

            result.AddRange(userClaims);
            if(roles != null && roles.Count >0) 
            {
                foreach(var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    result.AddRange(roleClaims);
                }
            }
            return result;
        }
    }
}
