using System;

public class Application
{
    public int Id { get; set; }

    public int? JobId { get; set; }

    public int? FreelancerId { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime? DateApplied { get; set; } = DateTime.Now;

    public virtual JobInfo? Job { get; set; }
    public virtual User? Freelancer { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (!JobId.HasValue || JobId <= 0)
        {
            validationMessage += "Job ID must be greater than 0.\n";
        }

        if (!FreelancerId.HasValue || FreelancerId <= 0)
        {
            validationMessage += "Freelancer ID must be greater than 0.\n";
        }

        if (string.IsNullOrWhiteSpace(CoverLetter))
        {
            validationMessage += "Cover letter is required.\n";
        }
        else if (CoverLetter.Length > 1000)
        {
            validationMessage += "Cover letter cannot exceed 1000 characters.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }

}
