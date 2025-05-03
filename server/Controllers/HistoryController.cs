using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET api/history
        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            try
            {
                var histories = await _historyService.GetHistoryAsync();

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
                var history = await _historyService.GetHistoryByIdAsync(id);

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
        public async Task<IActionResult> CreateHistory([FromBody] History history)
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

                var isCreated = await _historyService.CreateHistoryAsync(history);

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
        public async Task<IActionResult> DeleteHistory(int id)
        {
            try
            {
                var isDeleted = await _historyService.DeleteHistoryAsync(id);

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
