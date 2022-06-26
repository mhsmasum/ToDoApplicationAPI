using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Models;

namespace ToDoApp.API.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
    }
}
