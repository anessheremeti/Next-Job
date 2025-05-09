using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/message
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _messageService.GetMessagesAsync();

                if (messages == null || !messages.Any())
                    return NotFound("No messages found.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

        // GET: api/message/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            try
            {
                var message = await _messageService.GetMessageByIdAsync(id);
                if (message == null)
                    return NotFound($"Message with ID {id} not found.");

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving message: {ex.Message}");
            }
        }

        // GET: api/message/sender/{senderId}
        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetMessagesBySender(int senderId)
        {
            try
            {
                var messages = await _messageService.GetMessagesBySenderAsync(senderId);

                if (messages == null || !messages.Any())
                    return NotFound($"No messages found for sender ID {senderId}.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

        // GET: api/message/receiver/{receiverId}
        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetMessagesByReceiver(int receiverId)
        {
            try
            {
                var messages = await _messageService.GetMessagesByReceiverAsync(receiverId);

                if (messages == null || !messages.Any())
                    return NotFound($"No messages found for receiver ID {receiverId}.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

        // POST: api/message
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            try
            {
                if (message == null)
                    return BadRequest("Message data is required.");

                if (!message.IsValid(out var validationMessage))
                    return BadRequest(validationMessage);

                var created = await _messageService.CreateMessageAsync(message);
                if (!created)
                    return StatusCode(500, "Failed to create message.");

                return Ok("Message created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating message: {ex.Message}");
            }
        }

        // DELETE: api/message/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                var deleted = await _messageService.DeleteMessageAsync(id);
                if (!deleted)
                    return NotFound($"Message with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting message: {ex.Message}");
            }
        }
    }
}
