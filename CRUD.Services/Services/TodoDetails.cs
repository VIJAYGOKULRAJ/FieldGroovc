namespace CRUD.Services.Services
{
    public class TodoDetails
    {
        public string Username { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public string ToDo { get; set; }
        public bool SendEmailReminder { get; set; }
        public int ReminderFrequency { get; set; }
    }
}