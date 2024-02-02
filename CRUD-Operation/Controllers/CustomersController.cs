using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _cutomersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _cutomersRepository = customersRepository;
        }
        [HttpPost]
        public IActionResult CustomersAdd(Customers model)
        {

            _cutomersRepository.CustomersAdd(model);
            return Ok("Customer Added....!");


        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
