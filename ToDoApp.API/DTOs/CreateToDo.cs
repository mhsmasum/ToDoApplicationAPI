namespace ToDoApp.API.DTOs
{
    public class CreateToDo
    {
        public string Title { get;set; }
        public string Description { get;set; }
        public DateTime DueDate { get; set; }
    }
}
