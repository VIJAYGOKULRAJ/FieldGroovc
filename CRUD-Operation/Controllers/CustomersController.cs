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
        public async Task<IActionResult> CustomersAdd([FromBody] Customers model)
        {
            try
            {
                var result = await _cutomersRepository.CustomersAddAsync(model);
                Console.WriteLine(result);
                return Ok("Operation completed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customerWithEstimate = _cutomersRepository.GetById(id);

                if (customerWithEstimate == null)
                {
                    // Return a 404 Not Found response if the customer is not found

                    return NotFound();
                }

                return Ok(customerWithEstimate);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("{id}/AssignName")]
        public async Task<IActionResult> PostAssignName(int id, [FromBody] AssignName name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var changedAssignName = await _cutomersRepository._AssignName(id, name);
                return Ok(changedAssignName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}/assignsaleperson")]
        public async Task<IActionResult> PostAssignSalePerson(int id, [FromBody] AssignSales name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var changedAssignName = await _cutomersRepository._AssignSales(id, name);
                return Ok(changedAssignName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
