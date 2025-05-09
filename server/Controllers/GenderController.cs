using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genders = _genderService.GetAllGenders();
            return Ok(genders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gender = _genderService.GetGenderById(id);
            if (gender == null)
                return NotFound("Gender not found.");
            return Ok(gender);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Gender gender)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _genderService.AddGender(gender);
            if (!success)
                return StatusCode(500, "Failed to create gender.");

            return Ok("Gender created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Gender gender)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _genderService.UpdateGender(gender);
            if (!success)
                return NotFound("Gender not found or not updated.");

            return Ok("Gender updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _genderService.DeleteGender(id);
            if (!success)
                return NotFound("Gender not found or not deleted.");

            return Ok("Gender deleted successfully.");
        }
    }
}
