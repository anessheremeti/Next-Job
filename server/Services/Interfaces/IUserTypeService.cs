using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetUserTypesAsync();
        Task<UserType?> GetUserTypeByIdAsync(int id);
        Task<bool> CreateUserTypeAsync(UserType userType);
        Task<bool> UpdateUserTypeAsync(int id, UserType userType);
        Task<bool> DeleteUserTypeAsync(int id);
    }
}
