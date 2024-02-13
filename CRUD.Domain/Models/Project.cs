using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    [Key]
    public string Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string CompanyId { get; set; }

    [ForeignKey("CustomerId")]
    public string? CustomerId { get; set; }

    public int ProjectNumber { get; set; }

    public DateTime? DateCreated { get; set; } = DateTime.Now;

    public string? Status { get; set; }

    public string? Confidence { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public int? TaxRate { get; set; }

    public string? CustomField1 { get; set; }

    public string? CustomField2 { get; set; }

    public string? CustomField3 { get; set; }

    public string? CustomField4 { get; set; }

    public string? CustomField5 { get; set; }

    public bool? QuantitiesUpdated { get; set; }

    public string? Owner { get; set; }

    public string? Assignee { get; set; }

    public bool? FollowUp { get; set; }

    public string? ContactId { get; set; }

    public DateTime? FollowUpDate { get; set; } = DateTime.Now;

    public string? SiteAddress1 { get; set; }

    public string? SiteAddress2 { get; set; }

    public string? SiteCity { get; set; }

    public string? SiteState { get; set; }

    public string? SiteZip { get; set; }

    public bool? DisplayOnEstimate { get; set; }

    public bool? DisplayOnWorkOrder { get; set; }

    public bool? DisplayOnInvoice { get; set; }

    public string? SiteLotNumber { get; set; }

    public string? EstimateNotes { get; set; }

    public string? CreatedBy { get; set; }

    public string? SiteCounty { get; set; }

    public bool? SiteCityLimits { get; set; }

    public string? LocationId { get; set; }

    public DateTime? DateModified { get; set; } = DateTime.Now;

    public string? ModifiedBy { get; set; }

    public bool? Archived { get; set; }

    public string? Type { get; set; }

    public string? Action { get; set; }

    public DateTime? BidExpirationDate { get; set; } = DateTime.Now;

    public string? AssignedUserId { get; set; }

    public string? LeadSource { get; set; }

    public string? CityLimits { get; set; }

    public string? Reason { get; set; }

    public string? SecondaryOwner { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? LostReason { get; set; }

    public string? ProjectManager { get; set; }

    public string? Subdivision { get; set; }

    public string? PlanName { get; set; }

    public bool? NeedsWorkOrder { get; set; }

    public decimal? SalesCommissionRate { get; set; }

    public decimal? EstimatorCommissionRate { get; set; }

    public decimal? ProjectManagementCommissionRate { get; set; }

    public string? SiteAddressId { get; set; }

    public bool? InvoiceCompleteOverride { get; set; }

    public string? AlternateContactId { get; set; }

    public bool? Locked { get; set; }

    public string? LostReason2 { get; set; }

    public string? Reason2 { get; set; }

    public DateTime? LostDate { get; set; } = DateTime.Now;             

    public string? RetainageType { get; set; }

    public decimal? RetainageAmount { get; set; }

    public bool? OwnerInsuranceProgram { get; set; }

    public string? JobPermitted { get; set; }
}
