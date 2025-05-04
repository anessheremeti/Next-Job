using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IJobInfoService
{
    Task<IEnumerable<JobInfo>> GetAllAsync();
    Task<JobInfo?> GetByIdAsync(int id);
    Task<bool> CreateAsync(JobInfoCreateRequest request);
    Task<bool> UpdateAsync(int id, JobInfoCreateRequest request);
    Task<bool> DeleteAsync(int id);
}
