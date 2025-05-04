using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> CreateUserAsync(User user, string plainPassword);
}
