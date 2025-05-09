using System;

public class Review
{
    public int Id { get; set; }

    public int ReviewerId { get; set; }

    public int ReviewedUserId { get; set; }

    public int? Rating { get; set; }  

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now; 

    public virtual User? Reviewer { get; set; }
    public virtual User? ReviewedUser { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (ReviewerId <= 0)
            validationMessage += "Reviewer ID must be greater than 0.\n";

        if (ReviewedUserId <= 0)
            validationMessage += "Reviewed User ID must be greater than 0.\n";

        if (!Rating.HasValue || Rating < 1 || Rating > 5)
            validationMessage += "Rating must be between 1 and 5.\n";

        if (string.IsNullOrWhiteSpace(Comment))
            validationMessage += "Comment cannot be empty.\n";

        return string.IsNullOrWhiteSpace(validationMessage);
    }
}
