﻿using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD_Operation.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;

        public UsersController(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Users>> GetallUsers()
        {
            return await _userRepository.GetUsers();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Users model)
        {
            if (ModelState.IsValid)
            {
                var userName = model.Name;
                var Subject = "Welcome to FiledGroovc Project.....!";
                var (plainTextBody, htmlBody) = EmailTemplateGenerator.GenerateSuccessfulLoginEmailBody(userName, model.Email);
                _emailSender.SendEmail(model.Email, Subject, plainTextBody, htmlBody);
                _userRepository.UserAdd(model);

                return Ok("Successfully Registered....!");
            }
            return BadRequest();

        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }

      

            
        [HttpGet("activate")]
        public async Task<IActionResult> ActivateAccount([FromQuery] string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user != null)
            {
                user.IsActive = true;
                await _userRepository.UpdateUser(user);

                return Ok(new { Message = "User activated successfully" });
            }
            return NotFound(new { Message = "User not found or activation failed" });
        }

        /*  [HttpPost]
          [Route("emailsender")]
          public IActionResult SendEmail([FromBody]string To, string Subject, string Body)
          {
              _emailSender.SendEmail(To , Subject , Body);
              return Ok("Email sends Successfully....!");
          }*/


       
    }
}
