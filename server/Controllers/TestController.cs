using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly DataDapper _dataDapper;

    public TestController(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    [HttpGet("test-db")]
    [AllowAnonymous]
    public IActionResult TestDbConnection()
    {
        try
        {
            var sql = "SELECT 1";
            var result = _dataDapper.LoadDataSingle<int>(sql, new { });
            return Ok(" Database connection is working.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $" Database connection failed: {ex.Message}");
        }
    }

    [HttpGet("protected")]
    [Authorize]
    public IActionResult GetProtected()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(ClaimTypes.Name)?.Value ?? "unknown";

        return Ok(new
        {
            Message = " Qasja u lejua. Ky është një endpoint i mbrojtur.",
            UserId = userId,
            Email = email
        });
    }
}
