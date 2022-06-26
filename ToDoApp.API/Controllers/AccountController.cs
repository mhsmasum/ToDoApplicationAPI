using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;
using ToDoApp.API.Services;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        
       
        public AccountController(UserManager<ApplicationUser> userManager,
            
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
           
            _signInManager = signInManager;
            _tokenService = tokenService;
           
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser model)
        {

            var applicationUser = new ApplicationUser()
            {
                Name = model.Name,
                UserName = model.Email,
                Email = model.Email,
                DateOfBirth = DateTime.Now,
                
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                _ = _userManager.AddToRoleAsync(applicationUser, "User");
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("Signin")]
        public async Task<IActionResult> Login(SignIn model)
        {
            var result = new ResponseResult();
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await _tokenService.GenerateToken(user);
                    result = !string.IsNullOrWhiteSpace(token.Token) ? new ResponseResult { Status = Status.Success, Data = token } : result;
                }
                else
                {
                    result = new ResponseResult { Status=Status.Success , Error = "No user found"};
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Status=Status.BadRequest , Error = ex});
                
            }

            return Ok(result);
        }
    }
}
