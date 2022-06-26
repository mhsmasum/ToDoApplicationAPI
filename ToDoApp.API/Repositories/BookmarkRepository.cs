using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Data;
using ToDoApp.API.Models;

namespace ToDoApp.API.Repositories
{
    public class BookmarkRepository : GenericRepository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<List<Bookmark>> GetByUser(string id)
        {
            return await _dbSet.Where(a => a.CreatedBy == id).ToListAsync();
        }
    }
}
