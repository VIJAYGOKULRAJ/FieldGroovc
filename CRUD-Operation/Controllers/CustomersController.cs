using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            
            return Ok("Operation completed successfully");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customersWithEstimates = await _cutomersRepository.GetAll();

               

                return Ok(customersWithEstimates);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
