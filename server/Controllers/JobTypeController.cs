using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _jobTypeService.GetAllJobTypes();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _jobTypeService.GetJobTypeById(id);
            if (type == null)
                return NotFound("Job type not found.");
            return Ok(type);
        }

        [HttpPost]
        public IActionResult Create([FromBody] JobType jobType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _jobTypeService.AddJobType(jobType);
            if (!success)
                return StatusCode(500, "Failed to create job type.");

            return Ok("Job type created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] JobType jobType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _jobTypeService.UpdateJobType(jobType);
            if (!success)
                return NotFound("Job type not found or not updated.");

            return Ok("Job type updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _jobTypeService.DeleteJobType(id);
            if (!success)
                return NotFound("Job type not found or not deleted.");

            return Ok("Job type deleted successfully.");
        }
    }
}
