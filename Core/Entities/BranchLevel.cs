using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Entities
{

    public class BranchLevel
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Area Area{ get; set; }
        [ForeignKey("Area")]
        public string AffiliatedBrId { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("User")]
        public string PrincipalId { get; set; }
        public int ContactPhone { get; set; }
        public DateTime OpenTime { get; set; }
        public LevelType LevelType { get; set; }
        public bool BranchStatus { get; set; }
        public Province Province { get; set; }
        [ForeignKey("Province")]
        public string SettlementDestination { get; set; }
        public string? Notes { get; set; }
        public BranchLevel BranchSuper { get; set; }
        [ForeignKey("BranchSuper")]
        public string? SuperId { get; set; }
        public ICollection<BranchLevel> BranchLevels { get; set; }
        public AppUser Creator { get; set; }
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public AppUser Modifier { get; set; }
        [ForeignKey("Modifier")]
        public string? ModifiedId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
    }
}
