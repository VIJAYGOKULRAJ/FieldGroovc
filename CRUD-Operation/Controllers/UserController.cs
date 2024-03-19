using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public IActionResult GetCalendarEvents()
        {
            try
            {
                var events = _user.GetUser();

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var events = _user.ListUser();

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddUser(User model)
        {
            _user.AddUser(model);
            return Ok("User Added....!");
        }

    }
}
