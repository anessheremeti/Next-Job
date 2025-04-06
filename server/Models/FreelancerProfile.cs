using System;
using System.ComponentModel.DataAnnotations;

public class FreelancerProfile
{
    public int Id { get; set; }

    public int UserId { get; set; } 

    public string? Skills { get; set; }

    public decimal HourlyRate { get; set; } 
    public string? PortfolioLink { get; set; } 

    public string? Location { get; set; }

    public DateTime LastDelivery { get; set; } 

    public DateTime MemberSince { get; set; } 

    public virtual User? User { get; set; }

    public void Validate()
    {
        try
        {
            if (UserId == 0)
                throw new ValidationException("UserId is required.");

            if (HourlyRate <= 0)
                throw new ValidationException("Hourly rate must be a positive number.");

            if (PortfolioLink != null && !Uri.IsWellFormedUriString(PortfolioLink, UriKind.Absolute))
                throw new ValidationException("Portfolio link must be a valid URL.");

            if (LastDelivery == default(DateTime))
                throw new ValidationException("Last delivery date is required.");
            if (MemberSince == default(DateTime))
                throw new ValidationException("Member since date is required.");

            if (Skills != null && Skills.Length > 500)
                throw new ValidationException("Skills should not exceed 500 characters.");

            Console.WriteLine("Validation successful.");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

