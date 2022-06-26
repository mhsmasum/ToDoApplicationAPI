using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {
        Task<List<ToDo>> GetByUser(string id);
    }
}
