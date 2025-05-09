using System;

public class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = string.Empty; 
    public bool? IsRead { get; set; } = false; 

    public DateTime? CreatedAt { get; set; } = DateTime.Now; 

    public virtual User? User { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (UserId <= 0)
        {
            validationMessage += "User ID must be greater than 0.\n";
        }

        if (string.IsNullOrWhiteSpace(Message))
        {
            validationMessage += "Message cannot be empty.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
