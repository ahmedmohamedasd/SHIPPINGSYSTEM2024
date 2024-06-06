using Core.SecurityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAccountService
    {
        Task<AuthModel> Login(LoginViewModel user, SymmetricSecurityKey securityKey);
    }
}
