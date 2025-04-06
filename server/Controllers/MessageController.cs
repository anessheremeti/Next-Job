using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public MessageController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/message
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var sql = "SELECT * FROM Message";

                var messages = await Task.Run(() => _dataDapper.LoadData<Message>(sql));

                if (messages == null || !messages.Any())
                {
                    return NotFound("No messages found.");
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/message/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM Message WHERE Id = {id}";

                var message = await Task.Run(() => _dataDapper.LoadDataSingle<Message>(sql));

                if (message == null)
                {
                    return NotFound($"Message with ID {id} not found.");
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/message/sender/{senderId}
        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetMessagesBySender(int senderId)
        {
            try
            {
                var sql = $"SELECT * FROM Message WHERE SenderId = {senderId}";

                var messages = await Task.Run(() => _dataDapper.LoadData<Message>(sql));

                if (messages == null || !messages.Any())
                {
                    return NotFound($"No messages found for sender ID {senderId}.");
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/message/receiver/{receiverId}
        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetMessagesByReceiver(int receiverId)
        {
            try
            {
                var sql = $"SELECT * FROM Message WHERE ReceiverId = {receiverId}";

                var messages = await Task.Run(() => _dataDapper.LoadData<Message>(sql));

                if (messages == null || !messages.Any())
                {
                    return NotFound($"No messages found for receiver ID {receiverId}.");
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/message
        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            try
            {
                if (message == null)
                {
                    return BadRequest("Message data is required.");
                }

                // Validate message data
                string validationMessage;
                if (!message.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO Message (SenderId, ReceiverId, MessageContent, DateTime) " +
                          $"VALUES ({message.SenderId}, {message.ReceiverId}, '{message.MessageContent}', '{message.DateTime}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create message.");
                }

                return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/message/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            try
            {
                var sql = $"DELETE FROM Message WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Message with ID {id} not found.");
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
