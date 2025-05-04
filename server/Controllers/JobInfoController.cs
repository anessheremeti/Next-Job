using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        var success = await _jobInfoService.CreateAsync(request);
        if (!success) return StatusCode(500, "Failed to create job.");

        return Ok("Job created successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] JobInfoCreateRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var success = await _jobInfoService.UpdateAsync(id, request);
        if (!success) return StatusCode(500, "Failed to update job.");

        return Ok("Job updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobInfoService.DeleteAsync(id);
        if (!success) return StatusCode(500, "Failed to delete job.");

        return Ok("Job deleted successfully.");
    }
}
    