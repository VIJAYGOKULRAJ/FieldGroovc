using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string CompanyName { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }
        public string ReorderContact { get; set; }
        public bool? Active { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string IntegrationId { get; set; }
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string Website { get; set; }
        public string QuickbooksId { get; set; }
        public DateTime? QuickbooksSyncDate { get; set; }
        public string QuickbooksSyncToken { get; set; }
        public string QuickBookDesktopID { get; set; }
        public DateTime? QuickBooksDesktopSyncDate { get; set; }
    }
}
