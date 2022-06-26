using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public interface IReminderRepository: IGenericRepository<Reminder>
    {
        Task<List<Reminder>> GetByUser(string id);
    }
}
