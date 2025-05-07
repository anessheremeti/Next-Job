using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required]
    public int UserTypeId { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    public string? CompanyName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Image { get; set; } 
}
