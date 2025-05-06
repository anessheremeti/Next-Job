using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnglishLevelController : ControllerBase
    {
        private readonly IEnglishLevelService _englishLevelService;

        public EnglishLevelController(IEnglishLevelService englishLevelService)
        {
            _englishLevelService = englishLevelService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var levels = _englishLevelService.GetAllLevels();
            return Ok(levels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var level = _englishLevelService.GetLevelById(id);
            if (level == null)
                return NotFound("English level not found.");
            return Ok(level);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EnglishLevel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _englishLevelService.AddLevel(level);
            if (!success)
                return StatusCode(500, "Failed to create English level.");

            return Ok("English level created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] EnglishLevel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _englishLevelService.UpdateLevel(level);
            if (!success)
                return NotFound("English level not found or not updated.");

            return Ok("English level updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _englishLevelService.DeleteLevel(id);
            if (!success)
                return NotFound("English level not found or not deleted.");

            return Ok("English level deleted successfully.");
        }
    }
}
