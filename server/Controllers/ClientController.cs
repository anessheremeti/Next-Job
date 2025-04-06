using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfileController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public ClientProfileController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/clientprofile
        [HttpGet]
        public async Task<IActionResult> GetClientProfiles()
        {
            try
            {
                var sql = "SELECT * FROM ClientProfiles";

                var clientProfiles = await Task.Run(() => _dataDapper.LoadData<ClientProfile>(sql));

                if (clientProfiles == null || !clientProfiles.Any())
                {
                    return NotFound("No client profiles found.");
                }

                return Ok(clientProfiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/clientprofile/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProfileById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM ClientProfiles WHERE Id = {id}";

                var clientProfile = await Task.Run(() => _dataDapper.LoadDataSingle<ClientProfile>(sql));

                if (clientProfile == null)
                {
                    return NotFound($"Client profile with ID {id} not found.");
                }

                return Ok(clientProfile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/clientprofile
        [HttpPost]
        public IActionResult CreateClientProfile([FromBody] ClientProfile clientProfile)
        {
            try
            {
                if (clientProfile == null || !clientProfile.isValid())
                {
                    return BadRequest("Invalid client profile data.");
                }

                var sql = $"INSERT INTO ClientProfiles (UserId, Image, Skills, JobSuccess, TotalJobs, TotalHours, InQueueService, Location, LastDelivery, MemberSince, Education, Gender, EnglishLevel) " +
                          $"VALUES ({clientProfile.UserId}, '{clientProfile.Image}', '{clientProfile.Skills}', {clientProfile.JobSuccess}, {clientProfile.TotalJobs}, {clientProfile.TotalHours}, {clientProfile.InQueueService}, '{clientProfile.Location}', '{clientProfile.LastDelivery}', '{clientProfile.MemberSince}', '{clientProfile.Education}', '{clientProfile.Gender}', '{clientProfile.EnglishLevel}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create client profile.");
                }

                return CreatedAtAction(nameof(GetClientProfileById), new { id = clientProfile.Id }, clientProfile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/clientprofile/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClientProfile(int id, [FromBody] ClientProfile clientProfile)
        {
            try
            {
                if (clientProfile == null || id != clientProfile.Id || !clientProfile.isValid())
                {
                    return BadRequest("Invalid client profile data.");
                }

                var sql = $"UPDATE ClientProfiles SET UserId = {clientProfile.UserId}, Image = '{clientProfile.Image}', Skills = '{clientProfile.Skills}', " +
                          $"JobSuccess = {clientProfile.JobSuccess}, TotalJobs = {clientProfile.TotalJobs}, TotalHours = {clientProfile.TotalHours}, " +
                          $"InQueueService = {clientProfile.InQueueService}, Location = '{clientProfile.Location}', LastDelivery = '{clientProfile.LastDelivery}', " +
                          $"MemberSince = '{clientProfile.MemberSince}', Education = '{clientProfile.Education}', Gender = '{clientProfile.Gender}', " +
                          $"EnglishLevel = '{clientProfile.EnglishLevel}' WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

                if (!isUpdated)
                {
                    return StatusCode(500, "Failed to update client profile.");
                }

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/clientprofile/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClientProfile(int id)
        {
            try
            {
                var sql = $"DELETE FROM ClientProfiles WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Client profile with ID {id} not found.");
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
