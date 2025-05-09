using System.Collections.Generic;
using System.Threading.Tasks;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDetailsDto>> GetApplicationsAsync();
    Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);
    Task<IEnumerable<Application>> GetByFreelancerIdAsync(int freelancerId);
    Task<bool> ExistsAsync(int id);
    Task<ApplicationDetailsDto?> CreateAndReturnAsync(Application application); // ndryshimi këtu
    Task<bool> UpdateApplicationAsync(int id, Application application);
    Task<bool> DeleteApplicationAsync(int id);
}
