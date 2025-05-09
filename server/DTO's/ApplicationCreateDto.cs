public class ApplicationCreateDto
{
    public int JobId { get; set; }
    public int FreelancerId { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public DateTime DateApplied { get; set; } = DateTime.Now;
}
