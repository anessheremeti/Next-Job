public class History
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string? Action { get; set; }
    
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public virtual User? User { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (UserId <= 0)
        {
            validationMessage += "User ID must be greater than 0.\n";
        }

        if (string.IsNullOrWhiteSpace(Action))
        {
            validationMessage += "Action cannot be empty.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
