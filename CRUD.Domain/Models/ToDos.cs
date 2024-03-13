using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class ToDos
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyId { get; set; }

        public DateTime? DateCreated { get; set; }= DateTime.Now;

        public string? ToDo { get; set; } 

        public bool? Complete { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public bool? SendEmailReminder { get; set; }

        public DateTime? DateCompleted { get; set; }=DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }= DateTime.Now;

        public int? ReminderFrequency { get; set; }

        public DateTime? LastReminded { get; set; }= DateTime.Now;

        public string? CreatedBy { get; set; }

        public int? PriorFrequency { get; set; }

        public string? ProjectId { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 15)")]
        public decimal? ReminderLocationLongitude { get; set; }

        [Column(TypeName = "decimal(18, 15)")]
        public decimal? ReminderLocationLatitude { get; set; }

        public string? ReminderLocationName { get; set; }

        public bool? Starred { get; set; }

        public string? OpportunityId { get; set; }

        public string? CalendarEventId { get; set; }

        public string? CustomerId { get; set; }
    }
}
