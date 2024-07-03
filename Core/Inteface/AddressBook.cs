using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Inteface
{
    public class AddressBook
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? SecondPhone { get; set; }
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public string Street { get; set; }
        public bool Default { get; set; }


    }
}
