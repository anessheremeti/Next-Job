using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelloWorld.Data;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly DataDapper _dataDapper;
    private readonly IConfiguration _configuration;

    public AuthController(DataDapper dataDapper, IConfiguration configuration)
    {
        _dataDapper = dataDapper;
        _configuration = configuration;
    }

    // POST api/auth/signup
    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] User user)
    {
        if (user == null || !user.IsValid())
            return BadRequest("Invalid user data.");

        var checkEmailSql = "SELECT * FROM Users WHERE Email = @Email";
        var parameters = new { user.Email };
        var existingUser = _dataDapper.LoadDataSingle<User>(checkEmailSql, parameters);

        if (existingUser != null)
            return BadRequest("Email already in use.");

        if (string.IsNullOrEmpty(user.PasswordHash))
        {
            return BadRequest("Password cannot be empty.");
        }

        user.SetPassword(user.PasswordHash);

        var sql = @"INSERT INTO Users (UserType, FullName, CompanyName, Email, PasswordHash)
                    VALUES (@UserType, @FullName, @CompanyName, @Email, @PasswordHash)";

        var insertParams = new
        {
            user.UserType,
            user.FullName,
            user.CompanyName,
            user.Email,
            user.PasswordHash
        };

        bool isCreated = _dataDapper.ExecuteSqlOpen(sql, insertParams);

        if (!isCreated)
            return StatusCode(500, "Failed to register user.");

        return Ok("User registered successfully.");
    }

    // POST api/auth/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest login)
    {
        if (login == null)
            return BadRequest("Invalid login data.");

        var sql = "SELECT * FROM Users WHERE Email = @Email";
        var parameters = new { login.Email };

        var user = _dataDapper.LoadDataSingle<User>(sql, parameters);

        if (user == null)
        {
            return Unauthorized("User not found.");
        }

        if (string.IsNullOrEmpty(login.Password))
        {
            return Unauthorized("Password cannot be empty.");
        }

        if (!user.VerifyPassword(login.Password))
        {
            return Unauthorized("Invalid password.");
        }

        var token = GenerateJwtToken(user);

        return Ok(new { Token = token });
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
    
    private string GenerateJwtToken(User user)
    {
        var secretKey = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentException("JWT Secret Key is missing in the configuration.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email ?? "default@domain.com"),
            new Claim(ClaimTypes.Role, user.UserType ?? "user")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
