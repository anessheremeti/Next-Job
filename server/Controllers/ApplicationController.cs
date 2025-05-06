using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/application
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            try
            {
                var applications = await _applicationService.GetApplicationsAsync();

                if (applications == null || !applications.Any())
                {
                    return NotFound("No applications found.");
                }

                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/application/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            try
            {
                var application = await _applicationService.GetApplicationByIdAsync(id);

                if (application == null)
                {
                    return NotFound($"Application with ID {id} not found.");
                }

                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/application/freelancer/{freelancerId}
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetByFreelancerId(int freelancerId)
        {
            try
            {
                var applications = await _applicationService.GetByFreelancerIdAsync(freelancerId);

                if (applications == null || !applications.Any())
                {
                    return NotFound($"No applications found for freelancer ID {freelancerId}.");
                }

                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/application
        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] Application application)
        {
            try
            {
                if (application == null)
                {
                    return BadRequest("Application cannot be null.");
                }

                if (!application.IsValid(out var validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                bool isCreated = await _applicationService.CreateApplicationAsync(application);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create application.");
                }

                return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/application/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, [FromBody] Application application)
        {
            try
            {
                if (application == null || id != application.Id)
                {
                    return BadRequest("Invalid application data.");
                }

                if (!await _applicationService.ExistsAsync(id))
                {
                    return NotFound($"Application with ID {id} not found.");
                }

                if (!application.IsValid(out var validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                bool isUpdated = await _applicationService.UpdateApplicationAsync(id, application);

                if (!isUpdated)
                {
                    return StatusCode(500, "Failed to update application.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/application/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                if (!await _applicationService.ExistsAsync(id))
                {
                    return NotFound($"Application with ID {id} not found.");
                }

                bool isDeleted = await _applicationService.DeleteApplicationAsync(id);

                if (!isDeleted)
                {
                    return StatusCode(500, "Failed to delete application.");
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
