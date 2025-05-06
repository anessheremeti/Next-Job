using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IJobInfoService
{
<<<<<<< HEAD
    public interface IJobInfoService
    {
        Task<IEnumerable<JobInfo>> GetJobsAsync();
        Task<JobInfo?> GetJobByIdAsync(int id);
        Task<bool> CreateJobAsync(JobInfo job);
        Task<bool> UpdateJobAsync(int id, JobInfo job);
        Task<bool> DeleteJobAsync(int id);
    }
=======
    Task<IEnumerable<JobInfo>> GetAllAsync();
    Task<JobInfo?> GetByIdAsync(int id);
    Task<bool> CreateAsync(JobInfoCreateRequest request);
    Task<bool> UpdateAsync(int id, JobInfoCreateRequest request);
    Task<bool> DeleteAsync(int id);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
