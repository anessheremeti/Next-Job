using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public HistoryController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/history
        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            try
            {
                var sql = "SELECT * FROM History";

                var histories = await Task.Run(() => _dataDapper.LoadData<History>(sql));

                if (histories == null || !histories.Any())
                {
                    return NotFound("No history records found.");
                }

                return Ok(histories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/history/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM History WHERE Id = {id}";

                var history = await Task.Run(() => _dataDapper.LoadDataSingle<History>(sql));

                if (history == null)
                {
                    return NotFound($"History record with ID {id} not found.");
                }

                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/history
        [HttpPost]
        public IActionResult CreateHistory([FromBody] History history)
        {
            try
            {
                if (history == null)
                {
                    return BadRequest("History data is required.");
                }

                // Validate history data
                string validationMessage;
                if (!history.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO History (UserId, Action, Timestamp) " +
                          $"VALUES ({history.UserId}, '{history.Action}', '{history.Timestamp}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create history record.");
                }

                return CreatedAtAction(nameof(GetHistoryById), new { id = history.Id }, history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/history/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                var sql = $"DELETE FROM History WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"History record with ID {id} not found.");
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
