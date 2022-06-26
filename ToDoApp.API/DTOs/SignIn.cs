using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.DTOs
{
    public class SignIn
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
