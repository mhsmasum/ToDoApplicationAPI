using ToDoApp.API.DTOs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public interface ITokenService
    {
        Task<UserToken> GenerateToken(ApplicationUser user);
    }
}
