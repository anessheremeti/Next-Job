using System.Collections.Generic;
using System.Threading.Tasks;

 public interface IApplicationService
{
    Task<IEnumerable<Application>> GetApplicationsAsync();
<<<<<<< HEAD
    Task<Application> GetApplicationByIdAsync(int id);
    Task<IEnumerable<Application>> GetByFreelancerIdAsync(int freelancerId);
    Task<bool> ExistsAsync(int id);
=======
    Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    Task<bool> CreateApplicationAsync(Application application);
    Task<bool> UpdateApplicationAsync(int id, Application application);
    Task<bool> DeleteApplicationAsync(int id);
}
