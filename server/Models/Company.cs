using System;

public class Company
{
    public int Id { get; set; }

    public int? OwnerId { get; set; } 

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Website { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User? Owner { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Name))
        {
            validationMessage += "Company name is required.\n";
        }
        
        if (Name?.Length > 255)
        {
            validationMessage += "Company name cannot exceed 255 characters.\n";
        }

        if (Description?.Length > 1000)
        {
            validationMessage += "Description cannot exceed 1000 characters.\n";
        }

        if (!string.IsNullOrEmpty(Website) && !Uri.IsWellFormedUriString(Website, UriKind.Absolute))
        {
            validationMessage += "Website must be a valid URL.\n";
        }

        if (CreatedAt == default)
        {
            validationMessage += "Created date is required.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
