using HelloWorld.Models;
using System;

public class User
{
    public int Id { get; set; }

    public int UserTypeId { get; set; }

    public string? FullName { get; set; }

    public string? CompanyName { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public virtual UserType? UserType { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (UserTypeId <= 0)
            validationMessage += "UserTypeId is required.\n";

        if (string.IsNullOrWhiteSpace(Email))
            validationMessage += "Email is required.\n";

        if (string.IsNullOrWhiteSpace(PasswordHash))
            validationMessage += "Password is required.\n";

        if (string.IsNullOrWhiteSpace(FullName) && string.IsNullOrWhiteSpace(CompanyName))
            validationMessage += "FullName or CompanyName is required.\n";

        return string.IsNullOrEmpty(validationMessage);
    }

    public void SetPassword(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password cannot be empty");

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword)
    {
        return !string.IsNullOrWhiteSpace(plainPassword) &&
               !string.IsNullOrWhiteSpace(PasswordHash) &&
               BCrypt.Net.BCrypt.Verify(plainPassword, PasswordHash);
    }
}
