using Core.Inteface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class City : IDistinct
    {
        [Key]
        public string Id { get ; set ; }
        public string Name { get; set; }
        public Province Province { get; set; }
        [ForeignKey("Province")]
        public string ProvinceId { get; set; }
    }
}
