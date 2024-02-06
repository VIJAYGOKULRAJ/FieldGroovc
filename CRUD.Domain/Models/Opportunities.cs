using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Opportunities
    {
        [Key]
        public int OpportunityId { get; set; }
        public string? CompanyId { get; set; }
        [ForeignKey("Customers")]
        public int? CustomerId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public string? CompanyName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsExpired { get; set; }
        public DateTime? BidExpirationDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public string? Action { get; set; }
        public string? PhoneWork { get; set; }
        public string? PhoneCell { get; set; }
        public string? PhoneHome { get; set; }
        public string? Website { get; set; }
        public int? ConfidenceLevel { get; set; }
        public int? ReminderFrequency { get; set; }
        public DateTime? LastReminded { get; set; } = DateTime.Now;
        public string? LeadSource { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public string? ProjectId { get; set; }
        public bool? CommercialAccount { get; set; }
        public string? BillingAddress1 { get; set; }
        public string? BillingAddress2 { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZip { get; set; }
        public bool? Archived { get; set; }
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public string? ReferralSource { get; set; }
        public bool? BillingSameAsPhysical { get; set; }
        public string? ServicesRequested { get; set; }
        public string? ServicesInstalled { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? LocationId { get; set; }
        public bool? Converted { get; set; }
        public DateTime? ConvertedDate { get; set; } = DateTime.Now;
        public DateTime? BidDate { get; set; } = DateTime.Now;
        public string? BidTime { get; set; }
        public string? ProjectName { get; set; }
        public string? Terms { get; set; }

    }
}
