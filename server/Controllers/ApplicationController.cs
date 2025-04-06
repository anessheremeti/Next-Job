using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public ApplicationController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/application
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            try
            {
                var sql = "SELECT * FROM Applications";

                var applications = await Task.Run(() => _dataDapper.LoadData<Application>(sql));

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

        // GET api/application/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM Applications WHERE Id = {id}";

                var application = await Task.Run(() => _dataDapper.LoadDataSingle<Application>(sql));

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

        // POST api/application
        [HttpPost]
        public IActionResult CreateApplication([FromBody] Application application)
        {
            try
            {
                if (application == null || application.JobId == 0 || application.FreelancerId == 0)
                {
                    return BadRequest("Invalid application data.");
                }

                var sql = $"INSERT INTO Applications (JobId, FreelancerId, CoverLetter, DateApplied) " +
                          $"VALUES ({application.JobId}, {application.FreelancerId}, '{application.CoverLetter}', '{application.DateApplied}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

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

        // PUT api/application/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateApplication(int id, [FromBody] Application application)
        {
            try
            {
                if (application == null || id != application.Id)
                {
                    return BadRequest("Invalid application data.");
                }

                var sql = $"UPDATE Applications SET JobId = {application.JobId}, FreelancerId = {application.FreelancerId}, " +
                          $"CoverLetter = '{application.CoverLetter}', DateApplied = '{application.DateApplied}' " +
                          $"WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

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

        // DELETE api/application/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteApplication(int id)
        {
            try
            {
                var sql = $"DELETE FROM Applications WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Application with ID {id} not found.");
                }

                return NoContent();  // Successfully deleted.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
