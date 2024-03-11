using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public bool? SuperAdmin { get; set; }
        public string? DisplayName { get; set; }
        public string? LocationId { get; set; }
        public bool? TaskDashboardVisible { get; set; }
        public bool? OpportunityDashboardVisible { get; set; }
        public bool? OperationsDashboardVisible { get; set; }
        public bool? AccountingDashboardVisible { get; set; }
        public bool? InventoryDashboardVisible { get; set; }
        public string? Image { get; set; }
        public bool? LoggedIn { get; set; }
        public decimal? SalesGoal { get; set; }
        public string? Phone { get; set; }
        public bool? EnableTaskNotifications { get; set; }
        public string? DefaultGroupId { get; set; }
        public int? SquareFootageCapacity { get; set; }
        public int? MoneyCapacity { get; set; }
        public bool? RestrictedAccess { get; set; }
        public bool? DailyJobsNotification { get; set; }
        public string? Signature { get; set; }
        public string? Initials { get; set; }
        public string? SignatureStyle { get; set; }
        public decimal? CommissionRate { get; set; }
        public bool? Driver { get; set; }
        public string? AccessCode { get; set; }
        public decimal? MonthlyBreakEven { get; set; }
        public decimal? SalesCommissionRate { get; set; }
        public decimal? EstimatorCommissionRate { get; set; }
        public decimal? ProjectManagementCommissionRate { get; set; }
        public bool? PrivacyMode { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? ShowWorkAreaFirst { get; set; }
        public bool? DisableModalClickingOff { get; set; }
        public bool? ExcludeFromReports { get; set; }
        public string? SessionToken { get; set; }
        public DateTime? SessionTokenDate { get; set; }
        public string? EmailSignature { get; set; }
        public bool? AllowToEditUnitPrice { get; set; }
        public bool? ReadOnlyCalendar { get; set; }
        public string? TaskEventTextColor { get; set; }
        public string? TaskEventBackgroundColor { get; set; }
        public bool? AllowAddRemoveCreditHold { get; set; }
        public bool? AllowUserstoUpdatePricing { get; set; }
    }
}
