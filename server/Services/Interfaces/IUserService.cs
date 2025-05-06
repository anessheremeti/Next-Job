using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
<<<<<<< HEAD
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
=======
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> CreateUserAsync(User user, string plainPassword);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
