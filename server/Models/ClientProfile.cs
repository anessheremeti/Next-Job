<<<<<<< HEAD
using System;
using System.Linq;

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

    public string? Gender { get; set; }
    public string? EnglishLevel { get; set; }

    public string[] SkillList => (Skills ?? "")
        .Split(',', StringSplitOptions.RemoveEmptyEntries)
        .Select(s => s.Trim())
        .ToArray();

    public ClientProfile()
    {
        MemberSince = DateTime.Now;
        LastDelivery = DateTime.Now;
    }

    public bool IsValid()
    {
        var validGenders = new[] { "male", "female" };
        var validEnglishLevels = new[] { "beginner", "intermediate", "advanced", "fluent" };

        bool isGenderValid = string.IsNullOrEmpty(Gender) || validGenders.Contains(Gender.ToLower());
        bool isEnglishLevelValid = string.IsNullOrEmpty(EnglishLevel) || validEnglishLevels.Contains(EnglishLevel.ToLower());

        bool isJobSuccessValid = !JobSuccess.HasValue || (JobSuccess >= 0 && JobSuccess <= 100);

        return isGenderValid && isEnglishLevelValid && isJobSuccessValid;
=======
public class ClientProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
    public int JobSuccess { get; set; }
    public int TotalJobs { get; set; }
    public int TotalHours { get; set; }
    public int InQueueService { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime LastDelivery { get; set; }
    public DateTime MemberSince { get; set; }
    public string Education { get; set; } = string.Empty;
    public int GenderId { get; set; }
    public int EnglishLevelId { get; set; }

    public bool isValid()
    {
        return UserId > 0 &&
               !string.IsNullOrWhiteSpace(Image) &&
               !string.IsNullOrWhiteSpace(Skills) &&
               JobSuccess >= 0 &&
               TotalJobs >= 0 &&
               TotalHours >= 0 &&
               InQueueService >= 0 &&
               !string.IsNullOrWhiteSpace(Location) &&
               !string.IsNullOrWhiteSpace(Education) &&
               GenderId > 0 &&
               EnglishLevelId > 0;
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
