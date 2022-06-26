using ToDoApp.API.Repositories;

namespace ToDoApp.API.UOW
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDos { get; }
        INoteRepository Notes { get; }
        IBookmarkRepository Bookmarks { get; }
        IReminderRepository Reminders { get; }
        Task CompleteAsync();
    }
}
