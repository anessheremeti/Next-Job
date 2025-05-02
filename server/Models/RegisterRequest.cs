public class RegisterRequest
{
    public int UserTypeId { get; set; }

    public string? FullName { get; set; }

    public string? CompanyName { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? Role { get; set; } 
}
