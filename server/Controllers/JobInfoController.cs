using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Collections.Generic;
using System;
using System.Linq;
=======
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

[Route("api/[controller]")]
[ApiController]
public class JobInfoController : ControllerBase
{
    private readonly IJobInfoService _jobInfoService;

    public JobInfoController(IJobInfoService jobInfoService)
    {
        _jobInfoService = jobInfoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _jobInfoService.GetAllAsync();
        return Ok(jobs);
    }

<<<<<<< HEAD
        // GET api/jobinfo
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var jobs = await _jobInfoService.GetJobsAsync();
                if (jobs == null || !jobs.Any())
                    return NotFound("No jobs found.");
=======
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var job = await _jobInfoService.GetByIdAsync(id);
        if (job == null) return NotFound("Job not found.");
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] JobInfoCreateRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

        var success = await _jobInfoService.CreateAsync(request);
        if (!success) return StatusCode(500, "Failed to create job.");

<<<<<<< HEAD
        // GET api/jobinfo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            try
            {
                var job = await _jobInfoService.GetJobByIdAsync(id);
                if (job == null)
                    return NotFound($"Job with ID {id} not found.");
=======
        return Ok("Job created successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] JobInfoCreateRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

        var success = await _jobInfoService.UpdateAsync(id, request);
        if (!success) return StatusCode(500, "Failed to update job.");

<<<<<<< HEAD
        // POST api/jobinfo
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobInfo job)
        {
            try
            {
                if (job == null)
                    return BadRequest("Job data is required.");

                if (!job.IsValid(out string validationMessage))
                    return BadRequest(validationMessage);

                var isCreated = await _jobInfoService.CreateJobAsync(job);

                if (!isCreated)
                    return StatusCode(500, "Failed to create job.");

                return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/jobinfo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobInfo job)
        {
            try
            {
                if (job == null || id != job.Id)
                    return BadRequest("Invalid job data.");

                if (!job.IsValid(out string validationMessage))
                    return BadRequest(validationMessage);

                var isUpdated = await _jobInfoService.UpdateJobAsync(id, job);

                if (!isUpdated)
                    return StatusCode(500, "Failed to update job.");

                return NoContent();
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
                    return NotFound($"Job with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
=======
        return Ok("Job updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobInfoService.DeleteAsync(id);
        if (!success) return StatusCode(500, "Failed to delete job.");

        return Ok("Job deleted successfully.");
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }
}
    