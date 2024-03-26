using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("Estimates")]
        public int? EstimateId { get; set; }
        public DateTime? DateCreated { get; set; }=DateTime.Now;
        public string? CustomerType { get; set; }
        public string? AccountType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? PhysicalAddress1 { get; set; }
        public string? PhysicalAddress2 { get; set; }
        public string? PhysicalCity { get; set; }
        public string? PhysicalState { get; set; }
        public string? PhysicalZip { get; set; }
        public string? BillingAddress1 { get; set; }
        public string? BillingAddress2 { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZip { get; set; }
        public string? LeadSource { get; set; }
        public bool? MasterAccount { get; set; }
        public bool? Active { get; set; }
        public string? Notes { get; set; }
        public string? CustomField1 { get; set; }
        public string? CustomField2 { get; set; }
        public string? CustomField3 { get; set; }
        public string? CustomField4 { get; set; }
        public string? CustomField5 { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Salesman { get; set; }
        public string? PreferredInvoiceMethod { get; set; }
        public string? PhysicalCounty { get; set; }
        public string? Website { get; set; }
        public decimal? Discount { get; set; }
        public string? CreatedBy { get; set; }
        public bool? HouseAccount { get; set; }
        public bool? CreditHold { get; set; }
        public bool? DoNotQuote { get; set; }
        public int? Number { get; set; }
        public DateTime? DateModified { get; set; }= DateTime.Now;
        public bool? AllowSms { get; set; }
        public decimal? CreditBalance { get; set; }
        public bool? OptOutSmsMessages { get; set; }
        public bool? OptOutOfReminders { get; set; }
        public bool? PendingCreditApproval { get; set; }
        public string? BillingDepartmentEmail { get; set; }
        public string? PhoneWork { get; set; }
        public string? QuickbooksId { get; set; }
        public DateTime? QuickbooksSyncDate { get; set; } = DateTime.Now;
        public string? QuickbooksSyncToken { get; set; }
        public string? Latitude { get; set; }    
        public string? Longitude { get; set; }
        public string? DisplayName { get; set; }
        public string? PayaVaultId { get; set; }
        public string? PaymentMethodPreview { get; set; }
        public string? PayaVaultLocationId { get; set; }
        public string? Token { get; set; }
        public bool? OptOutEstimateReminders { get; set; }
        public string? QuickBookDesktopID { get; set; }
        public DateTime? QuickBooksDesktopSyncDate { get; set; }= DateTime.Now;

        public string? AccountTypeId { get; set; }

        public string AccountTypeId { get; set; }  

        public virtual Estimates? Estimate { get; set; }

    }


    public class AssignName
    {
        public string? FirstName { get; set; }
    }

    public class AssignSales
    {
        public string? Salesman { get; set; }
    }
}
