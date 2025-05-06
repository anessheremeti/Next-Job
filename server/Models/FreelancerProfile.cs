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
    public decimal HourlyRate { get; set; }

    [Url]
    [MaxLength(255)]
    public string? PortfolioLink { get; set; }

    [MaxLength(255)]
    public string? Location { get; set; }

    [Required]
    public DateTime LastDelivery { get; set; }

    [Required]
    public DateTime MemberSince { get; set; }

    public virtual User? User { get; set; }

    public void Validate()
    {
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
    }
}
