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
    public class Quotation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BranchLevel AffailiatedBranch { get; set; }
        [ForeignKey("AffailiatedBranch")]
        public string AffailiatedBranchCode { get; set; }
        public LevelType FinanceCentre { get; set; }
        public ProductType ProductType { get; set; }
        public Status EnableStatus { get; set; }
        public DateTime ActivationStartTime { get; set; }
        public DateTime ActivationEndTime { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
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
