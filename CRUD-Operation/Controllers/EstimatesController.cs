﻿using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    
    [Route("api/[controller]")] 
    [ApiController]
    public class EstimatesController : ControllerBase
    {
        private readonly IEstimatesRepository _estimatesRepository;

        public EstimatesController(IEstimatesRepository estimatesRepository)
        {
            _estimatesRepository = estimatesRepository;
        }
        // create estimate
        [HttpPost]
        public IActionResult CreateEstimates(Estimates model)
        {
            model.ChangeOrder = false;
            var result = _estimatesRepository.EstimatesAdd(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var estimate = _estimatesRepository.GetById(id);
            return Ok(estimate);
        }

        //Locked the estimate
        [HttpPut("blockedTheEstimate/{id}")]
        public IActionResult LockedTheEstimate(int id)
        {
            try
            {
                var result = _estimatesRepository.LockTheEstimate(id);
                return Ok(result);
            }
            catch (Exception ex)
            { 
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while locking the estimate.");
            }
        }

        //Change the default estimate will be true
        [HttpPut("changeDefaultEstimate/{id}")]
        public IActionResult ChangeTheDefaultEstimate(int id)
        {
            try
            {
                var result = _estimatesRepository.ChangeTheDefaultEstimate(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while locking the estimate.");
            }
        }

        [HttpPost("addEstimateWithChangeOrder")]
        public IActionResult AddEstimateWithChangeOrder(Estimates model)
        {
            try
            {
                model.ChangeOrder = true;
                var result = _estimatesRepository.EstimatesAdd(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditEstimate(int id, [FromBody] Estimates model)
        {
            try
            {
                var result = _estimatesRepository.EditEstimate(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("duplicateEstimate/{id}")]
        public IActionResult DuplicateEstimate(int id)
        {
            try
            {
                var duplicatedEstimate = _estimatesRepository.DuplicateEstimate(id);
                if (duplicatedEstimate != null)
                {
                    return Ok(duplicatedEstimate);
                }
                else
                {
                    return NotFound("Original estimate not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while duplicating the estimate.");
            }
        }

        //Assigned office location
        [HttpPut("editEstimateLocation/{id}")]
        public IActionResult EditEstimateLocation(int id,[FromBody] EstimateLocation location)
        {
            try
            {
                if(location != null)
                {
                    var result = _estimatesRepository.EditEstimateLocation(id, location);
                    return Ok(result);
                }
                return StatusCode(500, "Data not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
