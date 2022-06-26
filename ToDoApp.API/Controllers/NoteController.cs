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
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNote model)
        {



            return Ok(await _noteService.Save(model, HttpContext.GetUserId()));

        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateNote model)
        {



            return Ok(await _noteService.Update(model, HttpContext.GetUserId()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {



            return Ok(await _noteService.GetById(id, HttpContext.GetUserId()));

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _noteService.GetAll(HttpContext.GetUserId()));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _noteService.Delete(id, HttpContext.GetUserId()));

        }
    }
}
