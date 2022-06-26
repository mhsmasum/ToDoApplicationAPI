using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.DTOs;
using ToDoApp.API.Extensions;
using ToDoApp.API.Models;
using ToDoApp.API.Services;
using ToDoApp.API.UOW;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateToDo model)
        {

           

            return Ok( await _toDoService.SaveTodo(model , HttpContext.GetUserId()));

        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateToDo model)
        {



            return Ok(await _toDoService.UpdateToDo(model, HttpContext.GetUserId()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {



            return Ok(await _toDoService.GetById(id, HttpContext.GetUserId()));

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _toDoService.GetAll(HttpContext.GetUserId()));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _toDoService.Delete( id,HttpContext.GetUserId()));

        }

    }
}
