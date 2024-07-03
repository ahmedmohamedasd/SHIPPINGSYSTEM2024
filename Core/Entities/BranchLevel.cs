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
        public int Id { get; set; }
        public string Name { get; set; }
        public LevelType LevelType { get; set; }
        public BranchLevel BranchSuper { get; set; }
        [ForeignKey("BranchSuper")]
        public int? SuperID { get; set; }

        public ICollection<BranchLevel> BranchLevels { get; set; }

    }
}
