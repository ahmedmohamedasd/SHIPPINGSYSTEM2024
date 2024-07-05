using Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Province : IDistinct
    {
        public string Id {  get; set; }
        public string Name { get; set; }
    }
}
