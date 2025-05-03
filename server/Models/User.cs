using BCrypt.Net;
using System;

public class User
{
    public int Id { get; set; }
    public string? UserType { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
    }

    public bool IsValid()
    {
        if (UserType == "client" || UserType == "freelancer")
        {
            return !string.IsNullOrEmpty(FullName);
        }
        else if (UserType == "company")
        {
            return !string.IsNullOrEmpty(CompanyName);
        }
        return false;
    }

    public void SetPassword(string plainPassword)
    {
        if (string.IsNullOrEmpty(plainPassword))
        {
            throw new ArgumentException("Password cannot be empty");
        }

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword)
    {
        if (string.IsNullOrEmpty(plainPassword) || string.IsNullOrEmpty(PasswordHash))
        {
            return false;
        }

        return BCrypt.Net.BCrypt.Verify(plainPassword, PasswordHash);
    }
}
    