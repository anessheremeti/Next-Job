<<<<<<< HEAD
=======
using HelloWorld.Models;
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IUserTypeService
    {
<<<<<<< HEAD
        Task<IEnumerable<UserType>> GetUserTypesAsync();
        Task<UserType?> GetUserTypeByIdAsync(int id);
        Task<bool> CreateUserTypeAsync(UserType userType);
        Task<bool> UpdateUserTypeAsync(int id, UserType userType);
        Task<bool> DeleteUserTypeAsync(int id);
=======
        Task<IEnumerable<UserType>> GetAllAsync();
        Task<UserType?> GetByIdAsync(int id);
        Task<bool> CreateAsync(UserType userType);
        Task<bool> UpdateAsync(int id, UserType userType);
        Task<bool> DeleteAsync(int id);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
