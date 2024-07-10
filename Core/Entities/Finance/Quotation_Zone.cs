using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class Quotation_Zone
    {
        public Zone Zone { get; set; }
        [ForeignKey("Zone")]
        public int ZoneId { get; set; }
        public Quotation Quotation { get; set; }
        [ForeignKey("Quotation")]
        public int QuotationId { get; set; }
        public string TierName { get; set; }
        public virtual ICollection<Quotation_Zone_Formula> QuotationZones { get; set; } = new List<Quotation_Zone_Formula>();

    }
}
