using System;

public class JobInfo
{
    public int Id { get; set; }

    public string? JobTitle { get; set; }

    public int Vacancies { get; set; }

    public string? JobTypes { get; set; }

    public string? JobTag { get; set; }

    public string? JobCategory { get; set; }

    public string? BudgetType { get; set; }

    public decimal? Budget { get; set; }

    public string? ExperienceLevel { get; set; }

    public DateTime Deadline { get; set; }

    public string? JobDescription { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(JobTitle))
        {
            validationMessage += "Job title is required.\n";
        }
        else if (JobTitle.Length > 255)
        {
            validationMessage += "Job title cannot exceed 255 characters.\n";
        }

        if (Vacancies <= 0)
        {
            validationMessage += "Vacancies must be greater than 0.\n";
        }

        if (string.IsNullOrEmpty(JobTypes) || Array.IndexOf(new[] { "fulltime", "parttime", "contract" }, JobTypes.ToLower()) == -1)
        {
            validationMessage += "Job type must be one of the following: fulltime, parttime, contract.\n";
        }

        if (string.IsNullOrEmpty(BudgetType) || Array.IndexOf(new[] { "fixed", "range", "negotiable" }, BudgetType.ToLower()) == -1)
        {
            validationMessage += "Budget type must be one of the following: fixed, range, negotiable.\n";
        }

        if (Budget.HasValue && Budget.Value <= 0)
        {
            validationMessage += "Budget must be a positive number.\n";
        }

        if (string.IsNullOrEmpty(ExperienceLevel) || Array.IndexOf(new[] { "entry", "mid", "senior" }, ExperienceLevel.ToLower()) == -1)
        {
            validationMessage += "Experience level must be one of the following: entry, mid, senior.\n";
        }

        if (Deadline <= DateTime.Now)
        {
            validationMessage += "Deadline must be a future date.\n";
        }

        if (string.IsNullOrWhiteSpace(JobDescription))
        {
            validationMessage += "Job description is required.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }

}
