using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IJobInfoService
    {
        Task<IEnumerable<JobInfo>> GetJobsAsync();
        Task<JobInfo?> GetJobByIdAsync(int id);
        Task<bool> CreateJobAsync(JobInfo job);
        Task<bool> DeleteJobAsync(int id);
    }
}
