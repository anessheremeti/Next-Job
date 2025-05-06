using System.ComponentModel.DataAnnotations;

public class ConfirmResetRequest
{
<<<<<<< HEAD
    public string Token { get; set; } = string.Empty;

=======
    [Required(ErrorMessage = "Token is required.")]
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "New password is required.")]
    [MinLength(6, ErrorMessage = "New password must be at least 6 characters.")]
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    public string NewPassword { get; set; } = string.Empty;
}
