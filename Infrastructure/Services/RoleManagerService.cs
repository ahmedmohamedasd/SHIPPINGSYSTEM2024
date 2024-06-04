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
    public class RoleManagerService : IRoleManagerService
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleManagerService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IRole> All()
        {
            return _roleManager.Roles.Select(c => (IRole)c).ToList();
        }

        public async Task<IdentityResult> CreateRole(string name)
        {
           var newRole = new Role() { Name = name};
            return await _roleManager.CreateAsync(newRole);
        }

        public async Task Delete(string id)
        {
            var role = Get(id);
            if(role != null)
            {
                await _roleManager.DeleteAsync((Role)role);
            }
            throw new ApplicationException("Role Id is empty");
        }

        public async Task<IRole> FindByNameAsync(string roleName)
        {
           return await _roleManager.FindByNameAsync(roleName);
        }

        public IRole Get(string id)
        {
            return _roleManager.Roles.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IList<Claim>> GetClaimsAsync(IRole role)
        {
            return await _roleManager.GetClaimsAsync(role as Role);
        }

        public async Task<bool> IsRoleExists(string name, string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var role = Get(id);
                if (role.Name == name) return false;
            }
            var isRoleExists = await _roleManager.RoleExistsAsync(name);
            return isRoleExists;
        }

        public async Task UpdateRole(string id, IList<string> claims)
        {
            claims =claims ?? new List<string>();
            var role = Get(id);
            var roleClaims = await _roleManager.GetClaimsAsync((Role)role);

            var claimsToAdd = claims.Where(c => !roleClaims.Select(r => r.Value).Contains(c));
            var claimsToRemove = roleClaims.Where(c => !claims.Contains(c.Value));

            foreach(var claim in claimsToAdd)
            {
                await _roleManager.AddClaimAsync((Role)role, new Claim(ClaimTypes.Authentication, claim, ClaimValueTypes.String));
            }
            foreach(var claim in claimsToRemove)
            {
                await _roleManager.RemoveClaimAsync((Role)role, claim);
            }

        }

        public async Task UpdateRoleName(string id, string name)
        {
            var role = Get(id);
            if(role.Name != name)
            {
                role.Name = name;
                await _roleManager.UpdateAsync((Role)role);
            }
        }
    }
}
