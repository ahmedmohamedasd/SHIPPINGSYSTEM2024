using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class Quotation_Zone_Formula
    {
        public Formula Formula { get; set; }
        [ForeignKey("Formula")]
        public int FormulaId { get; set; }
        public Quotation_Zone Quotation_Zone { get; set; }
        [ForeignKey("Quotation_Zone")]
        public int Quotation_ZoneId { get; set; }
    }
}
