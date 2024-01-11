using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Invoices
    {
        [Key]
        public int InvoiceId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Leads")]
        public int LeadsId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DatePaid { get; set; }
        public string? Name { get; set; }
        public string? LineItemIds { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public string? Notes { get; set; }
        public string? LocationId { get; set; }
        public int Number { get; set; }
        public string? Status { get; set; }
        public string? Fineprint { get; set; }
        public bool? Void { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? ExportDate { get; set; }
        public string? QuickbooksId { get; set; }
        public DateTime? QuickbooksSyncDate { get; set; }
        public string? QuickbooksSyncToken { get; set; }
        public bool? OnlyShowPhaseTotal { get; set; }
        public bool? IsEstimateGenerated { get; set; }
        public string? QuickBookDesktopID { get; set; }
        public DateTime? QuickBooksDesktopSyncDate { get; set; }
        public string? QBDEditSequence { get; set; }
        public string? CustomNumber { get; set; }
    }
}
