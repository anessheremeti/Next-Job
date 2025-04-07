using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelloWorld.Data;

//E kemi testu lidhjen me databaz sepse me heret kemi hasur disa probleme

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
    public IActionResult TestDbConnection()
    {
        try
        {
            var sql = "SELECT 1";
            var result = _dataDapper.LoadDataSingle<int>(sql, new { });
            return Ok("Database connection is working.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Database connection failed: {ex.Message}");
        }
    }
}
