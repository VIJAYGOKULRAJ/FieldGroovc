using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectSD
{
    [Key]
    public string Id { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Customers Company { get; set; }

    public string LocationId { get; set; }
    public string CustomerId { get; set; }
    public string ContactId { get; set; }
    public string AlternateContactId { get; set; }
    public string Owner { get; set; }
    public string SecondaryOwner { get; set; }
    public string ProjectManager { get; set; }
    public string Assignee { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectNumber { get; set; }

    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }

    public DateTime? DateModified { get; set; }
    public string ModifiedBy { get; set; }

    public string Status { get; set; }
    public string Confidence { get; set; }

    [StringLength(250)]
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }

    public bool FollowUp { get; set; }
    public string FollowUpDate { get; set; }
    public bool QuantitiesUpdated { get; set; }

    [StringLength(100)]
    public string SiteAddress1 { get; set; }

    [StringLength(100)]
    public string SiteAddress2 { get; set; }

    [StringLength(50)]
    public string SiteCity { get; set; }

    [StringLength(50)]
    public string SiteState { get; set; }

    [StringLength(50)]
    public string SiteZip { get; set; }

    [StringLength(100)]
    public string SiteLotNumber { get; set; }

    [StringLength(75)]
    public string SiteCounty { get; set; }

    public string CustomField1 { get; set; }
    public string CustomField2 { get; set; }
    public string CustomField3 { get; set; }
    public string CustomField4 { get; set; }
    public string CustomField5 { get; set; }

    public bool Archived { get; set; }
    public string Type { get; set; }

    [StringLength(250)]
    public string Action { get; set; }

    public string BidExpirationDate { get; set; }
    public string AssignedUserId { get; set; }

    [StringLength(100)]
    public string LeadSource { get; set; }
    public string CityLimits { get; set; }

    [StringLength(500)]
    public string Reason { get; set; }

    [StringLength(50)]
    public string Latitude { get; set; }

    [StringLength(50)]
    public string Longitude { get; set; }

    public string LostReason { get; set; }

    [StringLength(65)]
    public string Subdivision { get; set; }

    public bool NeedsWorkOrder { get; set; }
    public bool InvoiceCompleteOverride { get; set; }

    [StringLength(100)]
    public string PlanName { get; set; }

    public decimal? SalesCommissionRate { get; set; }
    public decimal? EstimatorCommissionRate { get; set; }
    public decimal? ProjectManagementCommissionRate { get; set; }

    public bool Locked { get; set; }
    public string LostReason2 { get; set; }

    [StringLength(500)]
    public string Reason2 { get; set; }

    public DateTime LostDate { get; set; }

    [StringLength(30)]
    public string RetainageType { get; set; }
    public decimal RetainageAmount { get; set; }

    public bool OwnerInsuranceProgram { get; set; }

    [StringLength(50)]
    public string JobPermitted { get; set; }

   

    public bool HasCoordinates
    {
        get
        {
            return !string.IsNullOrEmpty(Longitude) && !string.IsNullOrEmpty(Latitude);
        }
    }

    public bool HasAddress
    {
        get
        {
            return !string.IsNullOrEmpty(Subdivision) || !string.IsNullOrEmpty(SiteLotNumber) || !string.IsNullOrEmpty(SiteAddress1) || !string.IsNullOrEmpty(SiteCity);
        }
    }

    public string Number
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(CompanyId))
            {
                return CompanyId.Substring(0, 5) + "-" + ProjectNumber.ToString().PadLeft(6, '0');
            }

            return ProjectNumber.ToString();
        }
    }

    public string SiteAddress
    {
        get
        {
            var street1 = SiteAddress1;
            var street2 = !string.IsNullOrEmpty(SiteAddress2) ? ", " + SiteAddress2 : "";

            return (street1 + street2 + ", " + SiteCity + ", " + SiteState + " " + SiteZip).Trim().TrimStart(',').TrimEnd(',');
        }
    }

    public string ActionNote { get; set; }
}
