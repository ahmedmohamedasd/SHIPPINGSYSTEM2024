using Core.Entities.Operation;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class Zone
    {
        public int Id { get; set; }
        public ZoneType ZoneType { get; set; }
        public BranchLevel AffailiatedBranch { get; set; }
        [ForeignKey("AffailiatedBranch")]
        public string AffailiatedBranchCode { get; set; }
        public string OriginsOrDestinations { get; set; }
        public QuotationType QuotationType { get; set; }
        public AppUser Creator { get; set; }

        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public AppUser Modifier { get; set; }

        [ForeignKey("Modifier")]
        public string? ModifiedId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public virtual ICollection<Quotation_Zone> QuotationZones { get; set; } = new List<Quotation_Zone>();

    }
}
