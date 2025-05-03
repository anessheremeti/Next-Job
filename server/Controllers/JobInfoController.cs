using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInfoController : ControllerBase
    {
        private readonly IJobInfoService _jobInfoService;

        public JobInfoController(IJobInfoService jobInfoService)
        {
            _jobInfoService = jobInfoService;
        }

        // GET api/jobinfo
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var jobs = await _jobInfoService.GetJobsAsync();

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
                var job = await _jobInfoService.GetJobByIdAsync(id);

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
        public async Task<IActionResult> CreateJob([FromBody] JobInfo job)
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

                var isCreated = await _jobInfoService.CreateJobAsync(job);

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
        public async Task<IActionResult> DeleteJob(int id)
        {
            try
            {
                var isDeleted = await _jobInfoService.DeleteJobAsync(id);

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
