using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            var result = await _userTypeService.GetUserTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userTypeService.GetUserTypeByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserType userType)
        {
            var success = await _userTypeService.CreateUserTypeAsync(userType);
            return success ? Ok("Created.") : StatusCode(500, "Creation failed.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserType userType)
        {
            var success = await _userTypeService.UpdateUserTypeAsync(id, userType);
            return success ? Ok("Updated.") : BadRequest("Invalid data.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userTypeService.DeleteUserTypeAsync(id);
            return success ? Ok("Deleted.") : NotFound();
        }
    }
}
