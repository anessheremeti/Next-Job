using System;

public class Payment
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; } = DateTime.Now;

    public int PaymentStatusId { get; set; }  // foreign key

    // Optional properties (related entities)
    public virtual Contract? Contract { get; set; }
    public virtual PaymentStatus? PaymentStatus { get; set; }

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

        if (PaymentStatusId <= 0)
        {
            validationMessage += "A valid PaymentStatusId is required.\n";
        }

        return string.IsNullOrEmpty(validationMessage);
    }
}
