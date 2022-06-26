using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Data;
using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<List<ToDo>> GetByUser(string id)
        {
           return await _dbSet.Where(a=>a.CreatedBy == id).ToListAsync();
        }
    }
}
