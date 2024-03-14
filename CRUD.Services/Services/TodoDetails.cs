using System.ComponentModel.DataAnnotations;

namespace CRUD.Services.Services
{
    public class TodoDetails
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; } 
        public string ToDo { get; set; }
        public bool SendEmailReminder { get; set; }
        public int ReminderFrequency { get; set; }
    }
}