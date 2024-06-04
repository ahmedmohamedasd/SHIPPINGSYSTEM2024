using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Constants;
using Application.Interface;
using Application.Setting;
using Core.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            var context = services.GetRequiredService<AppDbContext>();
            var settings = services.GetRequiredService<IOptions<Settings>>();
            if (settings.Value.AutoMigrateDatabase)
            {
                context.Database.Migrate();
                var _userManagerService = services.GetRequiredService<UserManager<AppUser>>();
                await Seeds(context, _userManagerService);
                await AdminSeed(services);
            }

        }
        public static async Task Seeds(AppDbContext _dbContext , UserManager<AppUser> _usermanager)
        {
            //var employee = new Employee()
            //{
            //    Name = "Test Employee",
            //    Email = "Test@gmail.com"
            //};
            //var employeeInDb = _dbContext.Employees.AsNoTracking().FirstAsync(c=>c.Name == employee.Name);
            //if(employeeInDb == null)
            //{
            //    _dbContext.Employees.Add(employee);
            //    _dbContext.SaveChanges();
            //}
            var user = new AppUser()
            {
                UserName = SystemConstants.Seeds.SeedUser.UserName,
                Email = SystemConstants.Seeds.SeedUser.Email,
                EmailConfirmed = true,
                FullName = SystemConstants.Seeds.SeedUser.FullName,
                CardNumber ="6769769763784"

            };
            var userInDb = await _usermanager.FindByNameAsync(SystemConstants.Seeds.SeedUser.UserName);
            if(userInDb != null)
            {
             await _usermanager.CreateAsync(user, SystemConstants.Seeds.SeedUser.Password);
            }

        }

        private static async Task AdminSeed(IServiceProvider serviceProvider)
        {
            try
            {
                await CreateAdmin(serviceProvider);
                await CreateRole(serviceProvider, SystemConstants.Seeds.SeedAdminRole.Name);
              await AddAllClaimsForRole(serviceProvider, SystemConstants.Seeds.SeedAdminRole.Name);
                await AssigneAdminToRole(serviceProvider, SystemConstants.Seeds.SeedAdmin.UserName, SystemConstants.Seeds.SeedAdminRole.Name);
            }catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private static async Task CreateAdmin(IServiceProvider serviceProvider)
        {
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                var adminUser = await userManager.FindByNameAsync(SystemConstants.Seeds.SeedAdmin.UserName);
                if (adminUser == null)
                {
                    var defaultAdmin = new AppUser { UserName = SystemConstants.Seeds.SeedAdmin.UserName, Email = SystemConstants.Seeds.SeedAdmin.Email , FullName =SystemConstants.Seeds.SeedAdmin.FullName ,CardNumber = SystemConstants.Seeds.SeedAdmin.CardNumber  };
                    var result = await userManager.CreateAsync(defaultAdmin, SystemConstants.Seeds.SeedAdmin.Password);
                    if (!result.Succeeded)
                    {
                        var error = string.Join(",", result.Errors.Select(e => e.Description).ToArray());
                        throw new ApplicationException(error);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
           
        }

        private static async Task CreateRole(IServiceProvider serviceProvider, string roleName)
        {
            try
            {
                var rolesManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

                var adminRole = await rolesManager.FindByNameAsync(roleName);
                if (adminRole == null)
                {
                    var result = await rolesManager.CreateAsync(new Role() { Name = roleName });
                    if (!result.Succeeded)
                    {
                        var error = string.Join(",", result.Errors.Select(e => e.Description).ToArray());
                        throw new ApplicationException(error);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        private static async Task AssigneAdminToRole(IServiceProvider serviceProvider, string userName, string roleName)
        {
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                //var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
                var adminUser = await userManager.FindByNameAsync(userName);
                var rols = await userManager.GetRolesAsync((AppUser) adminUser);

                var userInRol = rols.Where(c=>c == roleName).ToList();
                if (userInRol.Count == 0)
                {
                    await userManager.AddToRoleAsync(adminUser, roleName);
                }
                
                //var isAdminInRole = await userManager.IsInRoleAsync(adminUser, SystemConstants.Seeds.SeedAdminRole.Name);
                //if (!isAdminInRole)
                //{
                //}
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
           
        }

        private static async Task AddAllClaimsForRole(IServiceProvider serviceProvider, string roleName)
        {
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
                var roleManagerService = serviceProvider.GetRequiredService<IRoleManagerService>();
                var role = await roleManager.FindByNameAsync(roleName);
                var claims = SystemConstants.AuthorizationConstants.Claims.GetClaims().SelectMany(c => c.Value).ToList();
                if (role != null)
                {
                    var roleCLaims = await roleManagerService.GetClaimsAsync(role);
                    if (roleCLaims.Count() > 1) return;

                    if (claims.Count() > 0)
                    {
                        await roleManagerService.UpdateRole(role.Id, claims);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
