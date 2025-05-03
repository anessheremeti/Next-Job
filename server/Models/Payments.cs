using System;

public class Payment
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public string? Status { get; set; }

    public virtual Contract? Contract { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (ContractId <= 0)
        {
            validationMessage += "Contract ID must be greater than 0.\n";
        }

        if (Amount <= 0)
        {
            validationMessage += "Amount must be greater than 0.\n";
        }

        var validStatuses = new[] { "Pending", "Completed", "Failed" };
        if (string.IsNullOrEmpty(Status) || Array.IndexOf(validStatuses, Status) == -1)
        {
            validationMessage += "Status must be one of the following: Pending, Completed, Failed.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
