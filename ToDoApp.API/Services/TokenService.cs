using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;
        public TokenService(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        public async Task<UserToken> GenerateToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);



            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim("Roles", string.Join(",", roles)));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            if (!string.IsNullOrEmpty(token))
            {
                return new UserToken { Token = token };
            }
            else
            {
                return new UserToken();
            }
        }
    }
}
