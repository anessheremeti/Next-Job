
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
}
