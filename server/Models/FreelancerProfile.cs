using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class FreelancerProfile
{
    [Key]
    public int Id { get; set; }

<<<<<<< HEAD
=======
    [Required]
    [ForeignKey("User")]
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    public int? UserId { get; set; }

    [MaxLength(500)]
    public string? Skills { get; set; }

<<<<<<< HEAD
    public decimal? HourlyRate { get; set; }

    public string? PortfolioLink { get; set; }
=======
    [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be a positive number.")]
    public decimal HourlyRate { get; set; }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

    [Url]
    [MaxLength(255)]
    public string? PortfolioLink { get; set; }

    [MaxLength(255)]
    public string? Location { get; set; }

<<<<<<< HEAD
    public DateTime? LastDelivery { get; set; }

    public DateTime? MemberSince { get; set; }
=======
    [Required]
    public DateTime LastDelivery { get; set; }

    [Required]
    public DateTime MemberSince { get; set; }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

    public virtual User? User { get; set; }

    public bool IsValid(out string validationMessage)
    {
<<<<<<< HEAD
        validationMessage = string.Empty;

        if (UserId == null || UserId <= 0)
            validationMessage += "UserId is required.\n";

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
=======
        if (UserId <= 0)
            throw new ValidationException("UserId is required and must be greater than 0.");

        if (HourlyRate <= 0)
            throw new ValidationException("Hourly rate must be a positive number.");

        if (PortfolioLink != null && !Uri.IsWellFormedUriString(PortfolioLink, UriKind.Absolute))
            throw new ValidationException("Portfolio link must be a valid URL.");

        if (LastDelivery == default)
            throw new ValidationException("Last delivery date is required.");

        if (MemberSince == default)
            throw new ValidationException("Member since date is required.");

        if (Skills != null && Skills.Length > 500)
            throw new ValidationException("Skills should not exceed 500 characters.");
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
