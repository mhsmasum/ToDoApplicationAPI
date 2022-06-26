namespace ToDoApp.API.Models
{
    public class Bookmark:AuditEntity
    {
        public string Title { get;set; }
        public string URL { get; set; }
    }
}
