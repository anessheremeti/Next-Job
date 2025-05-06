using HelloWorld.Models;

public class User
{
    public int Id { get; set; }

<<<<<<< HEAD
    public int UserTypeId { get; set; }  
=======
    public int UserTypeId { get; set; }

    public UserType? UserType { get; set; }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

    public string? FullName { get; set; }

    public string? CompanyName { get; set; }
<<<<<<< HEAD
=======
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }   
    public DateTime CreatedAt { get; set; }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

    public string Email { get; set; } = string.Empty;

<<<<<<< HEAD
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
=======
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
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }

    public void SetPassword(string plainPassword)
    {
<<<<<<< HEAD
        if (string.IsNullOrEmpty(plainPassword))
=======
        if (string.IsNullOrWhiteSpace(plainPassword))
        {
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
            throw new ArgumentException("Password cannot be empty");

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword)
    {
<<<<<<< HEAD
        if (string.IsNullOrEmpty(plainPassword) || string.IsNullOrEmpty(PasswordHash))
            return false;

        return BCrypt.Net.BCrypt.Verify(plainPassword, PasswordHash);
=======
        return !string.IsNullOrWhiteSpace(plainPassword) &&
               !string.IsNullOrWhiteSpace(PasswordHash) &&
               BCrypt.Net.BCrypt.Verify(plainPassword, PasswordHash);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
