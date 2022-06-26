namespace ToDoApp.API.Models
{
    public class Note:AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
