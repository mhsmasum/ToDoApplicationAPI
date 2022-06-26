using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.DTOs
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Date of birth required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
