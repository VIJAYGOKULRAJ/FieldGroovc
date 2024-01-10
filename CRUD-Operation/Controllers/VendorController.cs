using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServices _vendorServices;
        public VendorController(IVendorServices vendorservice)
        {
            _vendorServices = vendorservice;
        }

        //Get All Vendors
        [HttpGet]
        public async Task<IEnumerable<Vendors>> GetAllVendors()
        {
            return await _vendorServices.GetVendors();
        }

        //Create Vendors
        [HttpPost]
        public async Task<IActionResult> CreateVendor(Vendors newVendor)
        {
            var result = _vendorServices.CreateVendor(newVendor);
            return Ok(result);  
        }

        //All Column Edit
        [HttpPut]
        public async Task<IActionResult> EditVendor(int id, )
        {

        }
    }
}
