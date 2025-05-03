using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
<<<<<<< HEAD
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = string.Empty;
=======
    public string? Email { get; set; }
    public string? Password { get; set; }
>>>>>>> d9cac020040ad9e00d122fea83f2e88bb79c1f02
}
