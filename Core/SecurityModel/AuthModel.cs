using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SecurityModel
{
    public class AuthModel
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Errors { get; set; }
        public bool IsLoggedSeccess { get; set; }
    }
}
