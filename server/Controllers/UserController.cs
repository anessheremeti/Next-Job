using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                if (users == null || !users.Any())
                    return NotFound("No users found.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound($"User with ID {id} not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
<<<<<<< HEAD
                if (user == null)
                    return BadRequest("User data is required.");

                if (!user.IsValid(out var validationMessage))
                    return BadRequest(validationMessage);

                var isCreated = await _userService.CreateUserAsync(user);
=======
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User
                {
                    UserTypeId = request.UserTypeId,
                    FullName = request.FullName,
                    CompanyName = request.CompanyName,
                    Email = request.Email
                };

                bool isCreated = await _userService.CreateUserAsync(user, request.Password);

>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
                if (!isCreated)
                    return StatusCode(500, "Failed to create user.");

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

<<<<<<< HEAD
        // PUT api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                if (user == null || id != user.Id)
                    return BadRequest("Invalid user data.");

                if (!user.IsValid(out var validationMessage))
                    return BadRequest(validationMessage);

                var isUpdated = await _userService.UpdateUserAsync(id, user);
                if (!isUpdated)
                    return StatusCode(500, "Failed to update user.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUserAsync(id);
                if (!isDeleted)
                    return NotFound($"User with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
=======
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
