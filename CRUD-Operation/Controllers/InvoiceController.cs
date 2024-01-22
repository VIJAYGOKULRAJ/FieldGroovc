using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_Operation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // create Invoice
        [HttpPost]
        public IActionResult CreateInvoice(Invoices model)
        {
            var result = _invoiceRepository.InvoiceCreate(model);
            return Ok(result);
        }


        //edit the invoice
        [HttpPut("{id}")]

        public IActionResult EditInvoice(int id, Invoices model)
        {
            var data = _invoiceRepository.InvoiceEdit(id, model);
            return Ok(data);
        }

        

    }
}
