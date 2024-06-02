using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAppUser
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
    }
}
