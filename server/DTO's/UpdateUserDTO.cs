public class UpdateUserDTO
{
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; } // Opsionale, për të lejuar ndryshimin e fjalëkalimit
}
