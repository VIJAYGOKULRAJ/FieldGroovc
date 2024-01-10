using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class InventoryItems
    {
        [Key]
        public int InventoryItemId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public string Sku { get; set; }
        public string Warehouse { get; set; }
        public string ReorderLevel { get; set; }
        public bool? Taxable { get; set; }
        public bool? Active { get; set; }
        public bool? UnlimitedQuantity { get; set; }
        public decimal? MinimumPrice { get; set; }
        public bool? SurchargeExempt { get; set; }
        [ForeignKey("Vendors")]
        public int VendorId { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string CustomField4 { get; set; }
        public string CustomField5 { get; set; }
        public int? LowQuantity { get; set; }
        public string Manufacturer { get; set; }
        public string LocationId { get; set; }
        public string ContingentId { get; set; }
        public string ContingentWorkArea { get; set; }
        public bool? NeedsManufacturerAssigned { get; set; }
        public string Barcode { get; set; }
        public decimal? Value { get; set; }
        public decimal? CommittedQuantity { get; set; }
        public decimal? AwaitingQuantity { get; set; }
        public decimal? TargetQuantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string Notes { get; set; }
        public DateTime? DateModified { get; set; }
        public string IntegrationId { get; set; }
        public string AdditionalFinePrint { get; set; }
        public string MasterId { get; set; }
        public decimal? BookPrice { get; set; }
    }
}
