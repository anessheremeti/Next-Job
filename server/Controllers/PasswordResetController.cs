using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;

[Route("api/[controller]")]
[ApiController]
public class PasswordResetController : ControllerBase
{
    private readonly DataDapper _dataDapper;

    public PasswordResetController(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    // POST api/passwordreset/forgot-password
    [HttpPost("forgot-password")]
    public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.NewPassword))
        {
            return BadRequest("Invalid input.");
        }

        var sql = "SELECT * FROM Users WHERE Email = @Email";
        var parameters = new { request.Email };

        var user = _dataDapper.LoadDataSingle<User>(sql, parameters);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        user.SetPassword(request.NewPassword);

        var updateSql = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Email = @Email";
        var updateParams = new { user.PasswordHash, request.Email };

        bool isUpdated = _dataDapper.ExecuteSqlOpen(updateSql, updateParams);

        if (!isUpdated)
        {
            return StatusCode(500, "Failed to reset password.");
        }

        return Ok("Password has been reset successfully.");
    }

    // POST api/passwordreset/request-password-reset
    [HttpPost("request-password-reset")]
    public IActionResult RequestPasswordReset([FromBody] string email)
    {
        if (string.IsNullOrEmpty(email))
            return BadRequest("Email is required.");

        var user = _dataDapper.LoadDataSingle<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });

        if (user == null)
            return NotFound("User not found.");

        var token = Guid.NewGuid().ToString();
        var expiration = DateTime.UtcNow.AddMinutes(15);

        var sql = @"INSERT INTO PasswordResetTokens (Email, Token, Expiration)
                    VALUES (@Email, @Token, @Expiration)";
        var parameters = new { Email = email, Token = token, Expiration = expiration };

        bool inserted = _dataDapper.ExecuteSqlOpen(sql, parameters);

        if (!inserted)
            return StatusCode(500, "Failed to create password reset token.");

        return Ok(new { Message = "Password reset token generated.", Token = token });
    }

    // POST api/passwordreset/confirm-password-reset
    [HttpPost("confirm-password-reset")]
    public IActionResult ConfirmPasswordReset([FromBody] ConfirmResetRequest request)
    {
        if (string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.NewPassword))
            return BadRequest("Token and new password are required.");

        var sql = @"SELECT * FROM PasswordResetTokens 
                    WHERE Token = @Token AND Expiration > @Now";
        var parameters = new { request.Token, Now = DateTime.UtcNow };

        var resetToken = _dataDapper.LoadDataSingle<dynamic>(sql, parameters);

        if (resetToken == null)
            return BadRequest("Invalid or expired token.");

        string email = resetToken.Email;

        var user = _dataDapper.LoadDataSingle<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });

        if (user == null)
            return NotFound("User not found.");

        user.SetPassword(request.NewPassword);

        var updateSql = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Email = @Email";
        var updateParams = new { user.PasswordHash, Email = email };

        var deleteSql = "DELETE FROM PasswordResetTokens WHERE Token = @Token";

        bool updated = _dataDapper.ExecuteSqlOpen(updateSql, updateParams);
        bool deleted = _dataDapper.ExecuteSqlOpen(deleteSql, new { request.Token });

        if (!updated)
            return StatusCode(500, "Failed to reset password.");

        return Ok("Password has been successfully reset.");
    }
}
