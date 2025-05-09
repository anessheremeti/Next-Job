using System;

public class ClientProfile
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? Image { get; set; }
    public string? Skills { get; set; }
    public decimal? JobSuccess { get; set; }
    public int? TotalJobs { get; set; }
    public int? TotalHours { get; set; }
    public int? InQueueService { get; set; }
    public string? Location { get; set; }
    public DateTime? LastDelivery { get; set; }
    public DateTime? MemberSince { get; set; }
    public string? Education { get; set; }
    public int? GenderId { get; set; }
    public int? EnglishLevelId { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (!UserId.HasValue || UserId <= 0)
            validationMessage += "UserId is required and must be greater than 0.\n";

        if (string.IsNullOrWhiteSpace(Skills))
            validationMessage += "Skills are required.\n";

        if (string.IsNullOrWhiteSpace(Location))
            validationMessage += "Location is required.\n";

        if (string.IsNullOrWhiteSpace(Education))
            validationMessage += "Education is required.\n";

        if (!GenderId.HasValue || GenderId <= 0)
            validationMessage += "GenderId is required and must be greater than 0.\n";

        if (!EnglishLevelId.HasValue || EnglishLevelId <= 0)
            validationMessage += "EnglishLevelId is required and must be greater than 0.\n";

        return string.IsNullOrEmpty(validationMessage);
    }




}
