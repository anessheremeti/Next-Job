using System;

public class Contract
{
    public int Id { get; set; }

    public int FreelancerId { get; set; }

    public int ClientId { get; set; }

    public int JobId { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual User? Freelancer { get; set; }
    public virtual User? Client { get; set; }
    public virtual JobInfo? Job { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (FreelancerId <= 0)
        {
            validationMessage += "Freelancer ID must be greater than 0.\n";
        }

        if (ClientId <= 0)
        {
            validationMessage += "Client ID must be greater than 0.\n";
        }

        if (JobId <= 0)
        {
            validationMessage += "Job ID must be greater than 0.\n";
        }

        var validStatuses = new[] { "Active", "Completed", "Cancelled" };
        if (string.IsNullOrEmpty(Status) || Array.IndexOf(validStatuses, Status) == -1)
        {
            validationMessage += "Status must be one of the following: Active, Completed, Cancelled.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
