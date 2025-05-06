using System;
using System.ComponentModel.DataAnnotations;

public class FreelancerProfile
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Skills { get; set; }

    public decimal? HourlyRate { get; set; }

    public string? PortfolioLink { get; set; }

    public string? Location { get; set; }

    public DateTime? LastDelivery { get; set; }

    public DateTime? MemberSince { get; set; }

    public virtual User? User { get; set; }

    public bool IsValid(out string validationMessage)
    {
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
    }
}
