using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Data;
using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public class ReminderRepository:GenericRepository<Reminder>, IReminderRepository
    {

        public ReminderRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<List<Reminder>> GetByUser(string id)
        {
            return await _dbSet.Where(a => a.CreatedBy == id).ToListAsync();
        }
    }
}
