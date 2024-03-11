using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDos _todos;

        public ToDosController(IToDos todos)
        {
            _todos = todos;
        }
        [HttpGet("GetTodos")]
        public IActionResult GetToDos()
        {
            try
            {
                var events = _todos.GetToDos();

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ToDosAdd(ToDos model)
        {
            await _todos.ToDosAdd(model);
            return Ok("Todos Added....!");
        }

    }
}
