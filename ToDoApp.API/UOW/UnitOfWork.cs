using ToDoApp.API.Data;
using ToDoApp.API.Repositories;

namespace ToDoApp.API.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            ToDos = new ToDoRepository(_context, _logger);
            Notes = new NoteRepository(_context, _logger);
            Bookmarks = new BookmarkRepository(_context, _logger);
            Reminders = new ReminderRepository(_context, _logger);

        }

        public IToDoRepository ToDos { get; private set; }
        public INoteRepository Notes { get; private set; }
        public IBookmarkRepository Bookmarks { get; private set; }
        public IReminderRepository Reminders { get; private set; }

       



        public async Task CompleteAsync()
        {
            try
            {
                var data = await _context.SaveChangesAsync();
            }
            catch (Exception aa)
            {
                var messge = aa.ToString();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
