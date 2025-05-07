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

    public bool IsValid()
    {
        return UserId.HasValue &&
               !string.IsNullOrWhiteSpace(Skills) &&
               !string.IsNullOrWhiteSpace(Location) &&
               !string.IsNullOrWhiteSpace(Education) &&
               GenderId.HasValue && GenderId > 0 &&
               EnglishLevelId.HasValue && EnglishLevelId > 0;
    }
}
