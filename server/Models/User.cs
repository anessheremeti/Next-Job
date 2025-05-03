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
    public bool IsValid(out string message)
    {
        if (string.IsNullOrEmpty(UserType))
        {
            message = "User type is required.";
            return false;
        }

        if (UserType == "client" || UserType == "freelancer")
        {
            if (string.IsNullOrEmpty(FullName))
            {
                message = "Full name is required for this user type.";
                return false;
            }
        }
        else if (UserType == "company")
        {
            if (string.IsNullOrEmpty(CompanyName))
            {
                message = "Company name is required for company users.";
                return false;
            }
        }
        else
        {
            message = "Invalid user type.";
            return false;
        }

        message = string.Empty;
        return true;
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
    