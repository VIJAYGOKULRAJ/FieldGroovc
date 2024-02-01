using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        public DateTime? DateCreated { get; set; }=DateTime.Now;
        public string ContactType { get; set; }
        public string ContactTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }
        public bool? OptOutSmsMessages { get; set; }
        public bool? OptOutOfReminders { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string CustomType { get; set; }
    }
}
