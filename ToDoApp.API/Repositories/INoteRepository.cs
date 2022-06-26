using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public interface INoteRepository:IGenericRepository<Note>
    {
        Task<List<Note>> GetByUser(string id);
    }
}
