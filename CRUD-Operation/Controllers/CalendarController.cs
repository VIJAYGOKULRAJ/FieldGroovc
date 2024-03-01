using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarEvent _calendarEvent;

        public CalendarController(ICalendarEvent calendarEvent)
        {
            _calendarEvent = calendarEvent;
        }

        [HttpGet("GetCalendarEvents")]
        public IActionResult GetCalendarEvents()
        {
            try
            {
                var events = _calendarEvent.GetCalendarEvents();

                return Ok(events);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }   
  
    }
}
