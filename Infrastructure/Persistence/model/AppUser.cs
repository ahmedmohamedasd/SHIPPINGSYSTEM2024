using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;

namespace Infrastructure.Persistence.model
{
    public class AppUser :IdentityUser , IAppUser
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
    }
}
