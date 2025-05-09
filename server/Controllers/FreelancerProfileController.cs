using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerProfileController : ControllerBase
    {
        private readonly IFreelancerProfileService _freelancerProfileService;

        public FreelancerProfileController(IFreelancerProfileService freelancerProfileService)
        {
            _freelancerProfileService = freelancerProfileService;
        }

        // GET: api/freelancerprofile
        [HttpGet]
        public async Task<IActionResult> GetFreelancerProfiles()
        {
            try
            {
                var profiles = await _freelancerProfileService.GetFreelancerProfilesAsync();

                if (profiles == null || !profiles.Any())
                    return NotFound("No freelancer profiles found.");

                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/freelancerprofile/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancerProfileById(int id)
        {
            try
            {
                var profile = await _freelancerProfileService.GetFreelancerProfileByIdAsync(id);

                if (profile == null)
                    return NotFound($"Freelancer profile with ID {id} not found.");

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/freelancerprofile
        [HttpPost]
        public async Task<IActionResult> CreateFreelancerProfile([FromBody] CreateFreelancerProfileDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var profile = new FreelancerProfile
                {
                    UserId = dto.UserId,
                    Skills = dto.Skills,
                    HourlyRate = dto.HourlyRate,
                    PortfolioLink = dto.PortfolioLink,
                    Location = dto.Location,
                    LastDelivery = dto.LastDelivery,
                    MemberSince = dto.MemberSince
                };

                if (!profile.IsValid(out string validationMessage))
                    return BadRequest($"Validation failed: {validationMessage}");

                var isCreated = await _freelancerProfileService.CreateFreelancerProfileAsync(profile);

                if (!isCreated)
                    return StatusCode(500, "Failed to create freelancer profile.");

                return CreatedAtAction(nameof(GetFreelancerProfileById), new { id = profile.Id }, profile);
            }
            catch (ValidationException ve)
            {
                return BadRequest(ve.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/freelancerprofile/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancerProfile(int id, [FromBody] FreelancerProfile profile)
        {
            try
            {
                if (profile == null || id != profile.Id)
                    return BadRequest("Invalid freelancer profile data.");

                if (!profile.IsValid(out string validationMessage))
                    return BadRequest($"Validation failed: {validationMessage}");

                var isUpdated = await _freelancerProfileService.UpdateFreelancerProfileAsync(id, profile);

                if (!isUpdated)
                    return StatusCode(500, "Failed to update freelancer profile.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/freelancerprofile/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancerProfile(int id)
        {
            try
            {
                var isDeleted = await _freelancerProfileService.DeleteFreelancerProfileAsync(id);

                if (!isDeleted)
                    return NotFound($"Freelancer profile with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
