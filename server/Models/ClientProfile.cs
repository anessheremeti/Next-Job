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
    }
}
