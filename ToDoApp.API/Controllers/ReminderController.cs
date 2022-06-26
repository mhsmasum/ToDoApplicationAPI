using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.DTOs;
using ToDoApp.API.Extensions;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {


        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateReminder model)
        {



            return Ok(await _reminderService.Save(model, HttpContext.GetUserId()));

        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateReminder model)
        {



            return Ok(await _reminderService.Update(model, HttpContext.GetUserId()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {



            return Ok(await _reminderService.GetById(id, HttpContext.GetUserId()));

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _reminderService.GetAll(HttpContext.GetUserId()));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _reminderService.Delete(id, HttpContext.GetUserId()));

        }
    }
}
