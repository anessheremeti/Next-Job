using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CreateUserRequest
{
    [Required]
    [JsonPropertyName("userTypeId")]
    public int UserTypeId { get; set; }

    [Required]
    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [Required, EmailAddress]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [Required, MinLength(6)]
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
