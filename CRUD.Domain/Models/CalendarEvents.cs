using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class CalendarEvents
    {
        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string? LocationId { get; set; }
        public string? TruckId { get; set; }
        public string? CrewId { get; set; }
        public string? Type { get; set; }
        public string? TypeId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Notes { get; set; }
        public decimal? PercentOfWorkOrder { get; set; }
    }
}
