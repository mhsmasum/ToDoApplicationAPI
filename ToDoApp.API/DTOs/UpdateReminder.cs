namespace ToDoApp.API.DTOs
{
    public class UpdateReminder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReminderTime { get; set; }
    }
}
