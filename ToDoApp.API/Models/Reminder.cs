namespace ToDoApp.API.Models
{
    public class Reminder:AuditEntity
    {
        public string Title { get; set; }
        public DateTime ReminderTime { get; set; }
    }
}
