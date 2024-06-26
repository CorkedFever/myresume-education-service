﻿using Corkedfever.Educations.Business;
using Corkedfever.Educations.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Educations.Service.Controllers
{
    [Route("educations")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet("GetEducations")]
        [ProducesResponseType(typeof(List<EducationModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEducations()
        {
            try
            {

                return Ok(_educationService.GetEducations());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("GetEducation/{id}")]
        [ProducesResponseType(typeof(EducationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEducationById(int id)
        {
            try
            {
                return Ok(_educationService.GetEducationById(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("GetEducationByName")]
        [ProducesResponseType(typeof(EducationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEducationByName(string name)
        {
            try
            {
                return Ok(_educationService.GetEducationByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateEducation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateEducation([FromBody] EducationModel education)
        {
            try
            {
                _educationService.CreateEducation(education);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
    }
}
