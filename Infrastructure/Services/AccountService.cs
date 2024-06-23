using Application.Interface;
using Core.Entities;
using Core.SecurityModel;
using Infrastructure.Persistence.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserManagerService _userManagerService;

        public AccountService(UserManager<AppUser> userManager, IUserManagerService userManagerService)
        {
            _userManager = userManager;
            _userManagerService = userManagerService;
        }
        public async Task<AuthModel> Login(LoginViewModel user , SymmetricSecurityKey securityKey)
        {
            AuthModel model;
            try
            {
                var userIndb = _userManager.Users.FirstOrDefault(c => c.NormalizedUserName == user.UserName);
                if (userIndb != null)
                {
                    if (await _userManager.CheckPasswordAsync(userIndb, user.Password))
                    {
                        var listOfClaims = await _userManagerService.GetClaimsAsync((AppUser)userIndb);
                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name ,user.UserName)
                        };
                        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        for (int i = 0; i < listOfClaims.Count; i++)
                        {
                            authClaims.Add(new Claim(listOfClaims[i].Type, listOfClaims[i].Value));
                        }
                        var tokenOptions = new JwtSecurityToken(
                            claims: authClaims,
                            expires: DateTime.Now.AddDays(30),
                            signingCredentials: signingCredentials
                            );
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                        model = new AuthModel()
                        {
                            Token = tokenString,
                            UserName = user.UserName,
                            Id = userIndb.Id,
                            IsLoggedSeccess = true
                        };
                        return model;

                    }
                }
                model = new AuthModel()
                {
                    IsLoggedSeccess = false,
                    Errors = "User Name or Password is Incorrect"
                };
                return model;
            }
            catch(Exception ex)
            {
                model = new AuthModel()
                {
                    Errors = ex.Message,
                    IsLoggedSeccess = false
                };
                return model;

            }
         
        }
    }
}
