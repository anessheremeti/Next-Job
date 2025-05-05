using HelloWorld.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }

    public UserType? UserType { get; set; }
     public DateTime? CreatedAt { get; set; }
    public string UserTypeName => UserType?.UserTypeName ?? "Unknown";
}
