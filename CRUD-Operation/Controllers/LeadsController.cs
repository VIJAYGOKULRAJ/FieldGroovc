﻿using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using CRUD_Operation.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsRepository _leadsRepository;
        private readonly IUserRepository _userRepository;
        public LeadsController(ILeadsRepository leadsRepository , IUserRepository userRepository)
        {
            _leadsRepository = leadsRepository;
            _userRepository = userRepository;
        }

        

        //leads add simultaneously added users
        [HttpPost("userWhileAddLeads")]
        public IActionResult userWhileAddLead(UserCreateWhileAddLeads model)
        {
            if(ModelState.IsValid)
            {
                Users newUser;
                Leads newLead;
                Users user = null;
                if (model.Users != null)
                {
                    newUser = new Users
                    {
                        Name = model.Users.Name,
                        IsActive = model.Users.IsActive,
                        Email = model.Users.Email,
                        IsDelete = model.Users.IsDelete,
                        Password = model.Users.Password,
                        PhoneNumber = model.Users.PhoneNumber,
                        IsAdmin = model.Users.IsAdmin,
                        CreatedBy = model.Users.CreatedBy,
                        CreatedDate = model.Users.CreatedDate,
                        UpdatedBy = model.Users.UpdatedBy,
                        UpdatedDate = model.Users.UpdatedDate,
                        AddressLine1 = model.Users.AddressLine1,
                        AddressLine2 = model.Users.AddressLine2,
                        Country = model.Users.Country,
                        County = model.Users.County,

                    };
                    _userRepository.UserAdd(newUser);
                    user = _userRepository.GetUserByEmail(newUser.Email);
                    newLead = new Leads
                    {
                        UserId = user.UserId,
                        AccountType = model.Leads.AccountType,
                        Status = model.Leads.Status,
                        ProjectName = model.Leads.ProjectName,
                        CreatedBy = model.Leads.CreatedBy,
                        UpdatedBy = model.Leads.UpdatedBy,

                    };
                    _leadsRepository.LeadsAdd(newLead);

                    return Ok("Successfully Created User and Leads....!");
                }
                    else
                    {
                         newLead = new Leads
                        {
                            UserId = model.Leads.UserId,
                            AccountType = model.Leads.AccountType,
                            Status = model.Leads.Status,
                            ProjectName = model.Leads.ProjectName,
                            CreatedBy = model.Leads.CreatedBy,
                            UpdatedBy = model.Leads.UpdatedBy,

                        };
                        _leadsRepository.LeadsAdd(newLead);

                        return Ok("Successfully Created Leads....!");
                    }
                
                  
                
            }
            return BadRequest("Invalid data");
        }

        // Get the all leads
        [HttpGet]
        public async Task<IEnumerable<Leads>> Get()
        {
            return await _leadsRepository.GetAll();
        }

        //get the leads by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lead = _leadsRepository.GetById(id);
            return Ok(lead);
        }

        // Edit the lead by using the id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Leads model)
        {
           

            try
            {
                await _leadsRepository.EditLeads(id, model);
                return Ok("");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
          
        }


    }
}
