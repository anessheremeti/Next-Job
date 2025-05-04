using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly DataDapper _dataDapper;

        public JobTypeService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            string sql = "SELECT JobTypeID, JobTypeName FROM JobType";
            return _dataDapper.LoadData<JobType>(sql);
        }

        public JobType? GetJobTypeById(int id)
        {
            string sql = "SELECT JobTypeID, JobTypeName FROM JobType WHERE JobTypeID = @Id";
            return _dataDapper.LoadDataSingle<JobType>(sql, new { Id = id });
        }

        public bool AddJobType(JobType jobType)
        {
            string sql = "INSERT INTO JobType (JobTypeName) VALUES (@JobTypeName)";
            return _dataDapper.ExecuteSqlOpen(sql, jobType);
        }

        public bool UpdateJobType(JobType jobType)
        {
            string sql = "UPDATE JobType SET JobTypeName = @JobTypeName WHERE JobTypeID = @JobTypeID";
            return _dataDapper.ExecuteSqlOpen(sql, jobType);
        }

        public bool DeleteJobType(int id)
        {
            string sql = "DELETE FROM JobType WHERE JobTypeID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
