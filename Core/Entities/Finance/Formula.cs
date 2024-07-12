using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class Formula
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxWeight { get; set; } = 0;
        public WeightingRoundMode WeightingRoundMode { get; set; }
        public string FormulaEquation { get; set; }
        public ICollection<Quotation_Zone_Formula> QuotationZones { get; set; } = new List<Quotation_Zone_Formula>();

    }
}
