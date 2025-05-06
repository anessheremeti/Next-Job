public class ApplicationDetailsDto
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int FreelancerId { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public DateTime DateApplied { get; set; }

    public string JobTitle { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
}
