<<<<<<< HEAD
public interface IJobTypeService
{
    Task<IEnumerable<JobType>> GetAllAsync();
=======
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IJobTypeService
    {
        IEnumerable<JobType> GetAllJobTypes();
        JobType? GetJobTypeById(int id);
        bool AddJobType(JobType jobType);
        bool UpdateJobType(JobType jobType);
        bool DeleteJobType(int id);
    }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
