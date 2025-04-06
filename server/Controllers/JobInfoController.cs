using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInfoController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public JobInfoController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/jobinfo
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var sql = "SELECT * FROM JobInfo";

                var jobs = await Task.Run(() => _dataDapper.LoadData<JobInfo>(sql));

                if (jobs == null || !jobs.Any())
                {
                    return NotFound("No jobs found.");
                }

                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/jobinfo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM JobInfo WHERE Id = {id}";

                var job = await Task.Run(() => _dataDapper.LoadDataSingle<JobInfo>(sql));

                if (job == null)
                {
                    return NotFound($"Job with ID {id} not found.");
                }

                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/jobinfo
        [HttpPost]
        public IActionResult CreateJob([FromBody] JobInfo job)
        {
            try
            {
                if (job == null)
                {
                    return BadRequest("Job data is required.");
                }

                // Validate job data
                string validationMessage;
                if (!job.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO JobInfo (JobTitle, Vacancies, JobTypes, JobTag, JobCategory, BudgetType, Budget, " +
                          $"ExperienceLevel, Deadline, JobDescription) " +
                          $"VALUES ('{job.JobTitle}', {job.Vacancies}, '{job.JobTypes}', '{job.JobTag}', '{job.JobCategory}', " +
                          $"'{job.BudgetType}', {job.Budget}, '{job.ExperienceLevel}', '{job.Deadline}', '{job.JobDescription}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create job.");
                }

                return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/jobinfo/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            try
            {
                var sql = $"DELETE FROM JobInfo WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Job with ID {id} not found.");
                }

                return NoContent();  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
