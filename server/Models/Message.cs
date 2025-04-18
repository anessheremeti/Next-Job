using System;

public class Message
{
    public int Id { get; set; }
    
    public int SenderId { get; set; }
    
    public int ReceiverId { get; set; }
    
    public string? MessageContent { get; set; }
    
    public DateTime DateTime { get; set; } = DateTime.Now;

    public virtual User? Sender { get; set; }
    public virtual User? Receiver { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (SenderId <= 0)
        {
            validationMessage += "Sender ID must be greater than 0.\n";
        }

        if (ReceiverId <= 0)
        {
            validationMessage += "Receiver ID must be greater than 0.\n";
        }

        if (string.IsNullOrWhiteSpace(MessageContent))
        {
            validationMessage += "Message content cannot be empty.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
