using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using CRUD_Operation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpPost]
        public IActionResult ContactsAdd(Contacts model)
        {
            
                _contactRepository.ContactsAdd(model);
                return Ok("Conatct Added....!");
            

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
