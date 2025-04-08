using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<bool> CreateCompanyAsync(Company company);
        Task<bool> UpdateCompanyAsync(int id, Company company);
        Task<bool> DeleteCompanyAsync(int id);
    }
}
