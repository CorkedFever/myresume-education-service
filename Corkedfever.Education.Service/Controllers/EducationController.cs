using Corkedfever.Education.Business;
using Corkedfever.Education.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Education.Service.Controllers
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
