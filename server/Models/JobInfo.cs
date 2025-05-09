public class JobInfo
{
    public int Id { get; set; }

    public string? JobTitle { get; set; }

    public int Vacancies { get; set; }

    public int? JobTypeId { get; set; }

    public string? JobTag { get; set; }

    public string? JobCategory { get; set; }

    public int? BudgetTypeId { get; set; }

    public decimal? Budget { get; set; }

    public int? ExperienceLevelId { get; set; }

    public DateTime Deadline { get; set; }

    public string? JobDescription { get; set; }

    public string? JobTypeName { get; set; }
    public string? BudgetTypeName { get; set; }
    public string? ExperienceLevelName { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(JobTitle))
            validationMessage += "Job title is required.\n";
        else if (JobTitle.Length > 255)
            validationMessage += "Job title cannot exceed 255 characters.\n";

        if (Vacancies <= 0)
            validationMessage += "Vacancies must be greater than 0.\n";

        if (JobTypeId == null || JobTypeId <= 0)
            validationMessage += "Valid Job Type ID is required.\n";

        if (BudgetTypeId == null || BudgetTypeId <= 0)
            validationMessage += "Valid Budget Type ID is required.\n";

        if (Budget.HasValue && Budget <= 0)
            validationMessage += "Budget must be a positive number if provided.\n";

        if (ExperienceLevelId == null || ExperienceLevelId <= 0)
            validationMessage += "Valid Experience Level ID is required.\n";

        if (Deadline <= DateTime.Now)
            validationMessage += "Deadline must be a future date.\n";

        if (string.IsNullOrWhiteSpace(JobDescription))
            validationMessage += "Job description is required.\n";

        return string.IsNullOrEmpty(validationMessage);
    }
}
