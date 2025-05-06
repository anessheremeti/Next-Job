using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
<<<<<<< HEAD
    public string Email { get; set; } = string.Empty;
=======
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    public string Password { get; set; } = string.Empty;
}
