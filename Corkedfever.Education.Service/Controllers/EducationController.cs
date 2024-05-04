﻿using Corkedfever.Educations.Business;
using Corkedfever.Educations.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Educations.Service.Controllers
{
    [Route("[controller]")]
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
        public IActionResult Get()
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
        
        [HttpGet]
        [Route("GetEducation/{id}")]
        [ProducesResponseType(typeof(EducationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
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
        
        [HttpGet]
        [Route("GetEducationByName")]
        [ProducesResponseType(typeof(EducationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string name)
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

        [HttpPost]
        [Route("CreateEducation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] EducationModel education)
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
