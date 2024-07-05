using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        public string OrderNumber { get; set; }
        public string? WaybillNumber { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone1 { get; set; }
        public string? SenderPhone2 { get; set; }
        public City SenderCity { get; set; }
        [ForeignKey("SenderCity")]
        public string? SenderCityId { get; set; }
        public string SenderAreaName { get; set; }
        public string SenderStreet { get; set;}
        public string RecieverName { get; set; }
        public string RecieverPhone1 { get; set; }
        public string? RecieverPhone2 { get; set; }
        public City RecieverCity { get; set; }
        [ForeignKey("RecieverCity")]
        public string? RecieverCityId { get; set; }
        public string RecieverAreaName { get; set; }
        public string RecieverStreet { get; set; }
        public string ClientOrderNo { get; set; }
        public int ItemWeight { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFees { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal COD { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal CODFees { get; set; } = 0;
        public bool Insured { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceValue { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceValueFees { get; set; } = 0;
        public int? CustomerPickupNo { get; set; }
        public string? CustomerPickupInfo{ get; set; }
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientBR { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? OriginCenter { get; set; }
        public string? DeliveryCenter { get; set; }

        public BranchLevel PickupBR { get; set; }
        [ForeignKey("PickupBR")]
        public int PickupBRId { get; set; }
        //public int DeliveryBRId { get; set; }
        //public int SigningBRId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? SigningTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AdditionalFees { get; set; }=0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalFees { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal FOD { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal FODFees { get;set; } = 0;
        public SignStatus Signed { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Length { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal VolumeWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PickupWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InboundWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal HubWeight { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal InternalWeight { get; set; } = 0;
        // public int CourierId { get; set; }
        //public string CourierName { get; set; }
        public VoidedStatus Voided { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        //public string LastUpdateBR { get; set; }
        public string? TripleNumber { get; set; }
        public int? OFDTimes { get; set; }
    }
}
