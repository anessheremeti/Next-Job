public class User
{
    public int Id { get; set; }

    public int UserTypeId { get; set; } // për përdorim me DB
    public string? UserType { get; set; } // për përdorim në token ose view

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
        if (string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(CompanyName))
        {
            message = "Full name or company name is required.";
            return false;
        }

        if (string.IsNullOrEmpty(Email))
        {
            message = "Email is required.";
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
