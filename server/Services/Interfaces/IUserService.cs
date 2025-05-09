public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> CreateUserAsync(User user, string plainPassword); 
    Task<bool> UpdateUserAsync(int id, User user);
    Task<bool> DeleteUserAsync(int id);
}
