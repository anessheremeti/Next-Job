using System;

public class Company
{
    public int Id { get; set; }
    public int? OwnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Website { get; set; }
    public DateTime? CreatedAt { get; set; }
    public virtual User? Owner { get; set; }

    public bool IsValid(out string validationMessage)
    {
        var messages = new List<string>();

        if (string.IsNullOrWhiteSpace(Name))
        {
            messages.Add("Company name is required.");
        }
        else if (Name.Length > 255)
        {
            messages.Add("Company name cannot exceed 255 characters.");
        }

        if (!string.IsNullOrWhiteSpace(Description) && Description.Length > 1000)
        {
            messages.Add("Description cannot exceed 1000 characters.");
        }

        if (!string.IsNullOrWhiteSpace(Website) && !Uri.IsWellFormedUriString(Website, UriKind.Absolute))
        {
            messages.Add("Website must be a valid URL.");
        }

        if (!CreatedAt.HasValue || CreatedAt == default)
        {
            messages.Add("Created date is required.");
        }

        validationMessage = string.Join("\n", messages);
        return messages.Count == 0;
    }
}
