using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public interface IBookmarkRepository: IGenericRepository<Bookmark>
    {
        Task<List<Bookmark>> GetByUser(string id);
    }
}
