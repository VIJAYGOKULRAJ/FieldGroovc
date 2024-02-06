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
        public async Task<IActionResult> CustomersAdd(Customers model)
        {
            var result = await _cutomersRepository.CustomersAddAsync(model);
            Console.WriteLine(result);

            // Assuming you want to return something meaningful, adjust accordingly
            return Ok("Operation completed successfully");
        }
        [HttpGet]
        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            return await _cutomersRepository.GetAllCustomers();
        }
    }
}
