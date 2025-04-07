using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class JobInfoService : IJobInfoService
    {
        private readonly DataDapper _dataDapper;

        public JobInfoService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<JobInfo>> GetJobsAsync()
        {
            try
            {
                var sql = "SELECT * FROM JobInfo";
                return await _dataDapper.LoadDataAsync<JobInfo>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving job records: {ex.Message}", ex);
            }
        }

        public async Task<JobInfo?> GetJobByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM JobInfo WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<JobInfo>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving job record with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateJobAsync(JobInfo job)
        {
            try
            {
                if (job == null)
                {
                    throw new ArgumentException("Job data is required.");
                }

                var sql = @"INSERT INTO JobInfo (JobTitle, Vacancies, JobTypes, JobTag, JobCategory, BudgetType, Budget, 
                            ExperienceLevel, Deadline, JobDescription) 
                            VALUES (@JobTitle, @Vacancies, @JobTypes, @JobTag, @JobCategory, @BudgetType, @Budget, 
                            @ExperienceLevel, @Deadline, @JobDescription)";

                return await _dataDapper.ExecuteSqlAsync(sql, job);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating job record: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM JobInfo WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting job record with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
