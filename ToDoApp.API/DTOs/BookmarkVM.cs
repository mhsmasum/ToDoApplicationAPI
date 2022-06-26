namespace ToDoApp.API.DTOs
{
    public class BookmarkVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
