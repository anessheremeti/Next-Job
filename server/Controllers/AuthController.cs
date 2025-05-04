using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using HelloWorld.Data;
using HelloWorld.Models;
using System;

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

    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (string.IsNullOrWhiteSpace(request.UserType))
            return BadRequest("User type is required.");

        // Merr ID-në për UserType nga emri (client, freelancer, company)
        var userTypeId = _dataDapper.LoadDataSingle<int>(
            "SELECT UserTypeID FROM UserType WHERE LOWER(UserTypeName) = LOWER(@UserTypeName)",
            new { UserTypeName = request.UserType });

        if (userTypeId == 0)
            return BadRequest("Invalid user type.");

        var user = new User
        {
            UserTypeId = userTypeId,
            FullName = request.FullName,
            CompanyName = request.CompanyName,
            Email = request.Email
        };

        user.SetPassword(request.Password);

        if (!user.IsValid(out string validationMessage))
            return BadRequest($"Invalid user data: {validationMessage}");

        var existingUser = _dataDapper.LoadDataSingle<User>(
            "SELECT * FROM Users WHERE email = @Email", new { request.Email });

        if (existingUser != null)
            return BadRequest("Email already in use.");

        var sql = @"INSERT INTO Users 
                    (user_type_id, full_name, company_name, email, password_hash, created_at)
                    VALUES 
                    (@UserTypeId, @FullName, @CompanyName, @Email, @PasswordHash, @CreatedAt)";

        var insertParams = new
        {
            user.UserTypeId,
            user.FullName,
            user.CompanyName,
            user.Email,
            user.PasswordHash,
            user.CreatedAt
        };

        try
        {
            bool isCreated = _dataDapper.ExecuteSqlOpen(sql, insertParams);
            if (!isCreated)
                return StatusCode(500, "User not inserted, no rows affected.");

            return Ok("User registered successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Exception: {ex.Message}");
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest login)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _dataDapper.LoadDataSingle<User>(
            @"SELECT u.id, u.user_type_id AS UserTypeId, ut.UserTypeID, ut.UserTypeName,
                     u.full_name AS FullName, u.company_name AS CompanyName, 
                     u.email, u.password_hash AS PasswordHash, u.created_at AS CreatedAt
              FROM Users u
              JOIN UserType ut ON u.user_type_id = ut.UserTypeID
              WHERE u.email = @Email", new { login.Email });

        if (user == null || !user.VerifyPassword(login.Password))
            return Unauthorized("Invalid credentials.");

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost("reset-confirm")]
    public IActionResult ConfirmResetPassword([FromBody] ConfirmResetRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var email = _dataDapper.LoadDataSingle<string>(
            "SELECT email FROM PasswordResetTokens WHERE token = @Token AND expiration > GETDATE()",
            new { request.Token });

        if (string.IsNullOrEmpty(email))
            return BadRequest("Invalid or expired token.");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        bool updated = _dataDapper.ExecuteSqlOpen(
            "UPDATE Users SET password_hash = @PasswordHash WHERE email = @Email",
            new { PasswordHash = hashedPassword, Email = email });

        if (!updated)
            return StatusCode(500, "Failed to reset password.");

        _dataDapper.ExecuteSqlOpen("DELETE FROM PasswordResetTokens WHERE token = @Token", new { request.Token });

        return Ok("Password has been reset successfully.");
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUser()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            return Unauthorized("User ID not found or invalid in token.");

        var user = _dataDapper.LoadDataSingle<User>(
            @"SELECT u.id, u.user_type_id AS UserTypeId, ut.UserTypeID, ut.UserTypeName,
                     u.full_name AS FullName, u.company_name AS CompanyName, 
                     u.email, u.created_at AS CreatedAt
              FROM Users u
              JOIN UserType ut ON u.user_type_id = ut.UserTypeID
              WHERE u.id = @Id", new { Id = userId });

        if (user == null)
            return NotFound("User not found.");

        return Ok(new
        {
            user.Id,
            user.FullName,
            user.CompanyName,
            user.Email,
            user.UserType,
            user.CreatedAt
        });
    }

    [HttpGet("test-db")]
    public IActionResult TestDbConnection()
    {
        try
        {
            var result = _dataDapper.LoadDataSingle<int>("SELECT 1", new { });
            return Ok("Database connection is working.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Database connection failed: {ex.Message}");
        }
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("AuthController po funksionon");
    }

    private string GenerateJwtToken(User user)
    {
        var secretKey = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            throw new ArgumentException("JWT Secret Key is missing or too short.");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email ?? "unknown"),
            new Claim(ClaimTypes.Role, user.UserType?.UserTypeName ?? "user")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
