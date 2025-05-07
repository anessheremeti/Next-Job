using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class FreelancerProfile
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("User")]
    public int? UserId { get; set; }

    [MaxLength(500)]
    public string? Skills { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be a positive number.")]
    public decimal? HourlyRate { get; set; }

    [Url]
    [MaxLength(255)]
    public string? PortfolioLink { get; set; }

    [MaxLength(255)]
    public string? Location { get; set; }

    [Required]
    public DateTime? LastDelivery { get; set; }

    [Required]
    public DateTime? MemberSince { get; set; }

    public virtual User? User { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (UserId == null || UserId <= 0)
            validationMessage += "UserId is required and must be greater than 0.\n";

        if (HourlyRate == null || HourlyRate <= 0)
            validationMessage += "Hourly rate must be a positive number.\n";

        if (!string.IsNullOrEmpty(PortfolioLink) && !Uri.IsWellFormedUriString(PortfolioLink, UriKind.Absolute))
            validationMessage += "Portfolio link must be a valid URL.\n";

        if (LastDelivery == null)
            validationMessage += "Last delivery date is required.\n";

        if (MemberSince == null)
            validationMessage += "Member since date is required.\n";

        if (!string.IsNullOrEmpty(Skills) && Skills.Length > 500)
            validationMessage += "Skills should not exceed 500 characters.\n";

        return string.IsNullOrEmpty(validationMessage);
    }
}
