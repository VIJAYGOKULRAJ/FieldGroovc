using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_Operation.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunities _Opportunities;
        public OpportunitiesController(IOpportunities Opportunities)
        {
            _Opportunities = Opportunities;
            

        }
        [HttpPut("ConvertToOpportunities/{id}")]
        public async Task<IActionResult> Put(int id)
        {

            try
            {
                await _Opportunities.ConvertToOpportunities(id);
                return Ok("Successfully Covert to Opportunities....!");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IEnumerable<Opportunities>> Get()
        {
            return await _Opportunities.GetAll();
        }



        [HttpPost]
        public IActionResult CreateOpportunity(Opportunities model)
        {
            if (ModelState.IsValid)
            {

                _Opportunities.AddOpportunities(model);


                return Ok("Successfully Created....!");
            }
            return BadRequest();
        }

        [HttpPost("DuplicateOpportunity/{id}")]
        public IActionResult DuplicateOpportunity(int id)
        {
            try
            {
                var duplicatedOpportunity = _Opportunities.DuplicateOpportunity(id);

                if (duplicatedOpportunity != null)
                {   
                    return Ok(duplicatedOpportunity);
                }
                else
                {
                    return NotFound("Original opportunity not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while duplicating the opportunity: {ex.Message}");
            }
        }
    }
}
