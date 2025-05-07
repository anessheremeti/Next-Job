using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllAsync();
        Task<UserType?> GetByIdAsync(int id);
        Task<bool> CreateAsync(UserType userType);
        Task<bool> UpdateAsync(int id, UserType userType);
        Task<bool> DeleteAsync(int id);
    }
}
