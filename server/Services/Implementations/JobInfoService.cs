using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class JobInfoService : IJobInfoService
{
    private readonly DataDapper _dataDapper;

    public JobInfoService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<JobInfo>> GetAllAsync()
    {
        var sql = @"
            SELECT j.*, 
                   jt.JobTypeName, 
                   bt.BudgetTypeName, 
                   el.ExperienceLevelName
            FROM JobInfo j
            LEFT JOIN JobType jt ON j.job_type_id = jt.JobTypeID
            LEFT JOIN BudgetType bt ON j.budget_type_id = bt.BudgetTypeID
            LEFT JOIN ExperienceLevel el ON j.experience_level_id = el.ExperienceLevelID";

        return await _dataDapper.LoadDataAsync<JobInfo>(sql);
    }

    public async Task<JobInfo?> GetByIdAsync(int id)
    {
        var sql = @"
            SELECT j.*, 
                   jt.JobTypeName, 
                   bt.BudgetTypeName, 
                   el.ExperienceLevelName
            FROM JobInfo j
            LEFT JOIN JobType jt ON j.job_type_id = jt.JobTypeID
            LEFT JOIN BudgetType bt ON j.budget_type_id = bt.BudgetTypeID
            LEFT JOIN ExperienceLevel el ON j.experience_level_id = el.ExperienceLevelID
            WHERE j.id = @Id";

        return await _dataDapper.LoadDataSingleAsync<JobInfo>(sql, new { Id = id });
    }

    public async Task<bool> CreateAsync(JobInfoCreateRequest request)
    {
        var sql = @"INSERT INTO JobInfo 
                    (job_title, vacancies, job_type_id, job_tag, job_category, 
                     budget_type_id, budget, experience_level_id, deadline, job_description)
                    VALUES 
                    (@JobTitle, @Vacancies, @JobTypeId, @JobTag, @JobCategory, 
                     @BudgetTypeId, @Budget, @ExperienceLevelId, @Deadline, @JobDescription)";

        return await _dataDapper.ExecuteSqlAsync(sql, request);
    }

    public async Task<bool> UpdateAsync(int id, JobInfoCreateRequest request)
    {
        var sql = @"UPDATE JobInfo SET
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

        var parameters = new
        {
            request.JobTitle,
            request.Vacancies,
            request.JobTypeId,
            request.JobTag,
            request.JobCategory,
            request.BudgetTypeId,
            request.Budget,
            request.ExperienceLevelId,
            request.Deadline,
            request.JobDescription,
            Id = id
        };

        return await _dataDapper.ExecuteSqlAsync(sql, parameters);
    }

<<<<<<< HEAD
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
=======
    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "DELETE FROM JobInfo WHERE id = @Id";
        return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
