using HelloWorld.Models;

public class User
{
    public int Id { get; set; }

    public int UserTypeId { get; set; }

    public UserType? UserType { get; set; }

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
        if (string.IsNullOrWhiteSpace(FullName) && string.IsNullOrWhiteSpace(CompanyName))
        {
            message = "Full name or company name is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            message = "Email is required.";
            return false;
        }

        message = string.Empty;
        return true;
    }

    public void SetPassword(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
        {
            throw new ArgumentException("Password cannot be empty");
        }

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword)
    {
        return !string.IsNullOrWhiteSpace(plainPassword) &&
               !string.IsNullOrWhiteSpace(PasswordHash) &&
               BCrypt.Net.BCrypt.Verify(plainPassword, PasswordHash);
    }
}
