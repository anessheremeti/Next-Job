using System;
using System.ComponentModel.DataAnnotations;

public class CreateFreelancerProfileDto
{
    [Required]
    public int UserId { get; set; }

    [MaxLength(500)]
    public string? Skills { get; set; }

    [Required]
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
}
