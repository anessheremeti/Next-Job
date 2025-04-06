using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerProfileController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public FreelancerProfileController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/freelancerprofile
        [HttpGet]
        public async Task<IActionResult> GetFreelancerProfiles()
        {
            try
            {
                var sql = "SELECT * FROM FreelancerProfiles";

                var profiles = await Task.Run(() => _dataDapper.LoadData<FreelancerProfile>(sql));

                if (profiles == null || !profiles.Any())
                {
                    return NotFound("No freelancer profiles found.");
                }

                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/freelancerprofile/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancerProfileById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM FreelancerProfiles WHERE Id = {id}";

                var profile = await Task.Run(() => _dataDapper.LoadDataSingle<FreelancerProfile>(sql));

                if (profile == null)
                {
                    return NotFound($"Freelancer profile with ID {id} not found.");
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/freelancerprofile
        [HttpPost]
        public IActionResult CreateFreelancerProfile([FromBody] FreelancerProfile profile)
        {
            try
            {
                if (profile == null)
                {
                    return BadRequest("Profile data is required.");
                }

                profile.Validate();

                var sql = $"INSERT INTO FreelancerProfiles (UserId, Skills, HourlyRate, PortfolioLink, Location, LastDelivery, MemberSince) " +
                          $"VALUES ({profile.UserId}, '{profile.Skills}', {profile.HourlyRate}, '{profile.PortfolioLink}', '{profile.Location}', '{profile.LastDelivery}', '{profile.MemberSince}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create freelancer profile.");
                }

                return CreatedAtAction(nameof(GetFreelancerProfileById), new { id = profile.Id }, profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/freelancerprofile/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateFreelancerProfile(int id, [FromBody] FreelancerProfile profile)
        {
            try
            {
                if (profile == null || id != profile.Id)
                {
                    return BadRequest("Invalid freelancer profile data.");
                }

                profile.Validate();

                var sql = $"UPDATE FreelancerProfiles SET UserId = {profile.UserId}, Skills = '{profile.Skills}', HourlyRate = {profile.HourlyRate}, " +
                          $"PortfolioLink = '{profile.PortfolioLink}', Location = '{profile.Location}', LastDelivery = '{profile.LastDelivery}', " +
                          $"MemberSince = '{profile.MemberSince}' WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

                if (!isUpdated)
                {
                    return StatusCode(500, "Failed to update freelancer profile.");
                }

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/freelancerprofile/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFreelancerProfile(int id)
        {
            try
            {
                var sql = $"DELETE FROM FreelancerProfiles WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Freelancer profile with ID {id} not found.");
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
