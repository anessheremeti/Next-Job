using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _userTypeService.GetAllAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var type = await _userTypeService.GetByIdAsync(id);
            if (type == null) return NotFound($"UserType with ID {id} not found.");
            return Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserType userType)
        {
            if (string.IsNullOrWhiteSpace(userType.UserTypeName))
                return BadRequest("UserTypeName is required.");

            var existing = await _userTypeService.GetAllAsync();
            if (existing.Any(t => t.UserTypeName.ToLower() == userType.UserTypeName.ToLower()))
                return Conflict("UserTypeName already exists.");

            var created = await _userTypeService.CreateAsync(userType);
            if (!created) return StatusCode(500, "Failed to create UserType.");

            return Ok("UserType created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserType userType)
        {
            var exists = await _userTypeService.GetByIdAsync(id);
            if (exists == null) return NotFound("UserType not found.");

            var updated = await _userTypeService.UpdateAsync(id, userType);
            if (!updated) return StatusCode(500, "Update failed.");

            return Ok("UserType updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _userTypeService.GetByIdAsync(id);
            if (exists == null) return NotFound("UserType not found.");

            var deleted = await _userTypeService.DeleteAsync(id);
            if (!deleted) return StatusCode(500, "Deletion failed.");

            return Ok("UserType deleted.");
        }
    }
}
