﻿using CRUD.Domain.Models;
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


        [HttpGet("cust")]
        public IActionResult GetCustomer()
        {
            try
            {
                var events = _cutomersRepository.GetCustomer();

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CustomersAdd([FromBody] Customers model)
        {
            try
            {

                var customer = new Customers
                {
                    DateCreated = model.DateCreated,
                    EstimateId = model.EstimateId,
                    CustomerType = model.CustomerType,
                    AccountType = model.AccountType,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    CompanyName = model.CompanyName,
                    PhysicalAddress1 = model.PhysicalAddress1,
                    PhysicalAddress2 = model.PhysicalAddress2,
                    PhysicalCity = model.PhysicalCity,
                    PhysicalState = model.PhysicalState,
                    PhysicalZip = model.PhysicalZip,
                    BillingAddress1 = model.BillingAddress1,
                    BillingAddress2 = model.BillingAddress2,
                    BillingCity = model.BillingCity,
                    BillingState = model.BillingState,
                    BillingZip = model.BillingZip,
                    LeadSource = model.LeadSource,
                    MasterAccount = model.MasterAccount,
                    Active = model.Active,
                    Notes = model.Notes,
                    CustomField1 = model.CustomField1,
                    CustomField2 = model.CustomField2,
                    CustomField3 = model.CustomField3,
                    CustomField4 = model.CustomField4,
                    CustomField5 = model.CustomField5,
                    Fax = model.Fax,
                    Mobile = model.Mobile,
                    Salesman = model.Salesman,
                    PreferredInvoiceMethod = model.PreferredInvoiceMethod,
                    PhysicalCounty = model.PhysicalCounty,
                    Website = model.Website,
                    Discount = model.Discount,
                    CreatedBy = model.CreatedBy,
                    HouseAccount = model.HouseAccount,
                    CreditHold = model.CreditHold,
                    DoNotQuote = model.DoNotQuote,
                    Number = model.Number,
                    DateModified = model.DateModified,
                    AllowSms = model.AllowSms,
                    CreditBalance = model.CreditBalance,
                    OptOutSmsMessages = model.OptOutSmsMessages,
                    OptOutOfReminders = model.OptOutOfReminders,
                    PendingCreditApproval = model.PendingCreditApproval,
                    BillingDepartmentEmail = model.BillingDepartmentEmail,
                    PhoneWork = model.PhoneWork,
                    QuickbooksId = model.QuickbooksId,
                    QuickbooksSyncDate = model.QuickbooksSyncDate,
                    QuickbooksSyncToken = model.QuickbooksSyncToken,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    DisplayName = model.DisplayName,
                    PayaVaultId = model.PayaVaultId,
                    PaymentMethodPreview = model.PaymentMethodPreview,
                    PayaVaultLocationId = model.PayaVaultLocationId,
                    Token = model.Token,
                    OptOutEstimateReminders = model.OptOutEstimateReminders,
                    QuickBookDesktopID = model.QuickBookDesktopID,
                    QuickBooksDesktopSyncDate = model.QuickBooksDesktopSyncDate,
                    // Ensure to map all other properties
                };

                var result = await _cutomersRepository.CustomersAddAsync(customer);
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
