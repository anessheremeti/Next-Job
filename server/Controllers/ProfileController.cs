using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly DataDapper _dataDapper;

    public ProfileController(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMyProfile()
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            var sql = @"SELECT id, user_type_id AS UserTypeId, full_name AS FullName, 
                        company_name AS CompanyName, email, created_at AS CreatedAt 
                        FROM Users WHERE id = @Id";

            var user = _dataDapper.LoadDataSingle<User>(sql, new { Id = userId });

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving profile: {ex.Message}");
        }
    }
}
