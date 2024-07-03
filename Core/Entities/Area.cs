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
    public class Area : IDistinct
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public string CityId { get; set; }
    }
}
