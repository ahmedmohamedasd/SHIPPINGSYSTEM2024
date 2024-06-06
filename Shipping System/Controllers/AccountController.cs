using Core.SecurityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Shipping_System.Helpers;
using ConfigurationManager = Shipping_System.Helpers.ConfigurationManager;
using Application.Interface;

namespace Shipping_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JWTSetting:Secret"]));
            var log = await _accountService.Login(user , securityKey);
            if (log.IsLoggedSeccess)
            {
                return Ok(log);
            }
            return BadRequest(log);
        }
    }
}
