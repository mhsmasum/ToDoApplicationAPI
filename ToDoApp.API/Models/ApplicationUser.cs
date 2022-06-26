using Microsoft.AspNetCore.Identity;

namespace ToDoApp.API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
