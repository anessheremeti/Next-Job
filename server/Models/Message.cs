using System;

public class Message
{
    public int Id { get; set; }
<<<<<<< HEAD

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string? MessageContent { get; set; }

    public DateTime? DateTime { get; set; } = System.DateTime.Now;

    public virtual User? Sender { get; set; }

    public virtual User? Receiver { get; set; }
=======

    public int? SenderId { get; set; }  
    public int? ReceiverId { get; set; }  

    public string MessageContent { get; set; } = string.Empty;

    public DateTime? DateTime { get; set; } 

    public User? Sender { get; set; }
    public User? Receiver { get; set; }
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (SenderId == null || SenderId <= 0)
        {
            validationMessage += "Sender ID must be a valid user ID.\n";
        }

        if (ReceiverId == null || ReceiverId <= 0)
        {
            validationMessage += "Receiver ID must be a valid user ID.\n";
        }

        if (string.IsNullOrWhiteSpace(MessageContent))
        {
            validationMessage += "Message content cannot be empty.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
