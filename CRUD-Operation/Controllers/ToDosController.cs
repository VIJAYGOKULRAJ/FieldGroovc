using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDos _todos;
        private readonly IUser _user;

        public ToDosController(IToDos todos, IUser user)
        {
            _todos = todos;
            _user = user;
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

        [HttpGet("GetTodoDetails")]
        public IActionResult GetTodoDetails()
                    {
            try
            {
                var todoDetails = _todos.GetTodoDetails();

                return Ok(todoDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("TodoWithUser")]
        public async Task<IActionResult> CreateTodoWithUser(TodoDetails request)
        {
            try
            {
                var user = _user.GetUserByUsername(request.Username);
                if (user == null)
                {
                    return NotFound($"User with username {request.Username} not found.");
                }

                var newTodo = new ToDos
                {
                    UserId = user.Id, 
                    ToDo = request.ToDo,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    SendEmailReminder=request.SendEmailReminder,
                    ReminderFrequency=request.ReminderFrequency
                };

                await _todos.ToDosAdd(newTodo);

                return Ok("ToDo added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}
