using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceLevelController : ControllerBase
    {
        private readonly IExperienceLevelService _experienceLevelService;

        public ExperienceLevelController(IExperienceLevelService experienceLevelService)
        {
            _experienceLevelService = experienceLevelService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var levels = _experienceLevelService.GetAllExperienceLevels();
            return Ok(levels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var level = _experienceLevelService.GetExperienceLevelById(id);
            if (level == null)
                return NotFound("Experience level not found.");
            return Ok(level);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExperienceLevel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _experienceLevelService.AddExperienceLevel(level);
            if (!success)
                return StatusCode(500, "Failed to create experience level.");

            return Ok("Experience level created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] ExperienceLevel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _experienceLevelService.UpdateExperienceLevel(level);
            if (!success)
                return NotFound("Experience level not found or not updated.");

            return Ok("Experience level updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _experienceLevelService.DeleteExperienceLevel(id);
            if (!success)
                return NotFound("Experience level not found or not deleted.");

            return Ok("Experience level deleted successfully.");
        }
    }
}
