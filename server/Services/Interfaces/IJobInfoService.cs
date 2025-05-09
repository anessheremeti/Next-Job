public interface IJobInfoService
{
    Task<IEnumerable<JobInfo>> GetJobsAsync();
    Task<JobInfo?> GetJobByIdAsync(int id);
    Task<bool> CreateJobAsync(JobInfo job);
    Task<bool> UpdateJobAsync(int id, JobInfo job);
    Task<bool> DeleteJobAsync(int id);
}
