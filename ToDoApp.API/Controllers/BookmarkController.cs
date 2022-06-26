using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.DTOs;
using ToDoApp.API.Extensions;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookmarkController : ControllerBase
    {



        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookmark model)
        {



            return Ok(await _bookmarkService.Save(model, HttpContext.GetUserId()));

        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBookmark model)
        {



            return Ok(await _bookmarkService.Update(model, HttpContext.GetUserId()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {



            return Ok(await _bookmarkService.GetById(id, HttpContext.GetUserId()));

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _bookmarkService.GetAll(HttpContext.GetUserId()));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _bookmarkService.Delete(id, HttpContext.GetUserId()));

        }
    }
}
