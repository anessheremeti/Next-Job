
public class User
{
    public int Id { get; set; }
    public string? UserType { get; set; }  
    public string? FullName { get; set; }  
    public string? CompanyName { get; set; } 
    public string? Email { get; set; } 
    public string? PasswordHash { get; set; } 
    public DateTime CreatedAt { get; set; } 

    public User()
    {
        CreatedAt = DateTime.Now;
    }

    public bool IsValid()
    {
        if (UserType == "client" || UserType == "freelancer")
        {
            return !string.IsNullOrEmpty(FullName);  
        }
        else if (UserType == "company")
        {
            return !string.IsNullOrEmpty(CompanyName);  
        }
        return false;
    }
}
