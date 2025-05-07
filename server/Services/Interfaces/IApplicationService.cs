using System.Collections.Generic;
using System.Threading.Tasks;

public interface IApplicationService
{
    Task<IEnumerable<Application>> GetApplicationsAsync();
    Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);  // përdor DTO për më shumë detaje
    Task<IEnumerable<Application>> GetByFreelancerIdAsync(int freelancerId);
    Task<bool> ExistsAsync(int id);
    Task<bool> CreateApplicationAsync(Application application);
    Task<bool> UpdateApplicationAsync(int id, Application application);
    Task<bool> DeleteApplicationAsync(int id);
}
