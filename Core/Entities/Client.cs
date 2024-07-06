using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int? TaxNumber { get; set; }
        public int? CRNumber { get; set; }// السجل التجارى 
        public string? NationalId { get; set; }
        public BranchLevel CustomerBR { get; set; }
        [ForeignKey("CustomerBR")]
        public string CustomerBRId { get; set; }
        public Status IsEnable {  get; set; }
        public DateTime? ContractStartTime { get; set; }
        public DateTime? ContractEndTime { get; set; }
        public DateTime? CreationTime { get; set; } = DateTime.Now;
        public Area Address { get; set; }
        [ForeignKey("Address")]
        public string? AddressId { get; set; }
        public string? Street { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxCODAmount { get; set; } = 0; // اعلى رقم العميل يقدر يحط فلوس على الشحنة
        public string? BankName { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? WalletCash { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public AppUser Creator { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public AppUser Modifier { get; set; }
      
        [ForeignKey("Modifier")]
        public string? ModifiedId { get; set; }
       
        public AppUser SalesPerson { get; set; }
       
        [ForeignKey("SalesPerson")]
        public string? SalesPersonId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public ChargeableWeightTypes ChargeableWeight { get; set; }
        public string? ContractUrl { get; set; } // الملف اللى فيه العقد

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
