using System;

public class ClientProfile
{
    public int Id { get; set; }
    // Foreign key per users 
    public int UserId { get; set; }
    public string? Image { get; set; }
    public string? Skills { get; set; }
    public decimal JobSuccess { get; set; }
    public int TotalJobs { get; set; }
    public int TotalHours { get; set; }
    public int InQueueService { get; set; }
    public string? Location { get; set; }
    public DateTime LastDelivery { get; set; }
    public DateTime MemberSince { get; set; }
    public string? Education { get; set; }
    public string? Gender { get; set; }
    public string? EnglishLevel { get; set; }


    public ClientProfile()
    {
        MemberSince = DateTime.Now;
        LastDelivery = DateTime.Now;
    }


    
    public bool isValid()
    {
        var validGenders = new[] { "male", "female" };  
        var validEnglishLevels = new[] { "beginner", "intermediate", "advanced", "fluent" };

        bool isGenderValid = validGenders.Contains(Gender?.ToLower()); 
        bool isEnglishLevelValid = validEnglishLevels.Contains(EnglishLevel?.ToLower());

        return isGenderValid && isEnglishLevelValid; 
    }
    
}
