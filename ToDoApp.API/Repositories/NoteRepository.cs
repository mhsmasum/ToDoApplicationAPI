using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Data;
using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<List<Note>> GetByUser(string id)
        {
            return await _dbSet.Where(a => a.CreatedBy == id).ToListAsync();
        }
    }
}
