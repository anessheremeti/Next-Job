using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public UserController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/user
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var sql = "SELECT * FROM Users";

                var users = await Task.Run(() => _dataDapper.LoadData<User>(sql));

                if (users == null || !users.Any())
                {
                    return NotFound("No users found.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM Users WHERE Id = {id}";

                var user = await Task.Run(() => _dataDapper.LoadDataSingle<User>(sql));

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (user == null || !user.IsValid())
                {
                    return BadRequest("Invalid user data.");
                }

                var sql = @"INSERT INTO Users (user_type, full_name, company_name, email, password_hash, created_at) 
                    VALUES (@UserType, @FullName, @CompanyName, @Email, @PasswordHash, @CreatedAt); 
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    UserType = user.UserType,
                    FullName = user.FullName,
                    CompanyName = user.CompanyName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    CreatedAt = user.CreatedAt
                };

                bool isCreated = await _dataDapper.ExecuteSqlAsync(sql, parameters);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create user.");
                }

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
