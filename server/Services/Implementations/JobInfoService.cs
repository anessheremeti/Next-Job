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
                var sql = "SELECT * FROM JobInfo WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<JobInfo>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving job record with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateJobAsync(int id, JobInfo job)
        {
            try
            {
                if (job == null || id != job.Id)
                {
                    throw new ArgumentException("Invalid job data or mismatched ID.");
                }

                if (!job.IsValid(out string validationMessage))
                {
                    throw new ArgumentException($"Validation failed: {validationMessage}");
                }

                var sql = @"
                    UPDATE JobInfo
                    SET 
                        job_title = @JobTitle,
                        vacancies = @Vacancies,
                        job_type_id = @JobTypeId,
                        job_tag = @JobTag,
                        job_category = @JobCategory,
                        budget_type_id = @BudgetTypeId,
                        budget = @Budget,
                        experience_level_id = @ExperienceLevelId,
                        deadline = @Deadline,
                        job_description = @JobDescription
                    WHERE id = @Id";

                return await _dataDapper.ExecuteSqlAsync(sql, job);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating job record with ID {id}: {ex.Message}", ex);
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

                if (!job.IsValid(out string validationMessage))
                {
                    throw new ArgumentException($"Validation failed: {validationMessage}");
                }

                var sql = @"
                    INSERT INTO JobInfo (
                        job_title, vacancies, job_type_id, job_tag, job_category,
                        budget_type_id, budget, experience_level_id, deadline, job_description
                    )
                    VALUES (
                        @JobTitle, @Vacancies, @JobTypeId, @JobTag, @JobCategory,
                        @BudgetTypeId, @Budget, @ExperienceLevelId, @Deadline, @JobDescription
                    )";

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
                var sql = "DELETE FROM JobInfo WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting job record with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
