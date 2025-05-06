using System;
using HelloWorld.Models; 

public class Contract
{
    public int Id { get; set; }
    public int FreelancerId { get; set; }
    public int ClientId { get; set; }
    public int JobId { get; set; }
<<<<<<< HEAD

    public DateTime? StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }

    public int ContractStatusId { get; set; }

    public string? StatusName { get; set; }  
=======
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public int ContractStatusId { get; set; }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

    public virtual User? Freelancer { get; set; }
    public virtual User? Client { get; set; }
    public virtual JobInfo? Job { get; set; }

    public virtual ContractStatus? ContractStatus { get; set; }

    public bool IsValid(out string validationMessage)
    {
        validationMessage = string.Empty;

        if (FreelancerId <= 0)
            validationMessage += "Freelancer ID must be greater than 0.\n";

        if (ClientId <= 0)
            validationMessage += "Client ID must be greater than 0.\n";

        if (JobId <= 0)
            validationMessage += "Job ID must be greater than 0.\n";

        if (ContractStatusId <= 0)
<<<<<<< HEAD
            validationMessage += "Contract status is required.\n";
=======
            validationMessage += "Contract status must be selected.\n";
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

        return string.IsNullOrEmpty(validationMessage);
    }
}
