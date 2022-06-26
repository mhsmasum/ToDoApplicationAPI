namespace ToDoApp.API.Models
{
    public class ToDo: AuditEntity
    {

        public ToDo()
        {
            IsComplete = false;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get;set; }
    }
}
