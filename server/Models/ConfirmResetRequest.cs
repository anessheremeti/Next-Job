using System.ComponentModel.DataAnnotations;

public class ConfirmResetRequest
{
<<<<<<< HEAD
    [Required(ErrorMessage = "Token is required.")]
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "New password is required.")]
    [MinLength(6, ErrorMessage = "New password must be at least 6 characters.")]
    public string NewPassword { get; set; } = string.Empty;
=======
    public string? Token { get; set; }
    public string? NewPassword { get; set; }
>>>>>>> d9cac020040ad9e00d122fea83f2e88bb79c1f02
}
