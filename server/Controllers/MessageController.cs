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

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _messageService.GetMessagesAsync();

                if (!messages.Any())
                    return NotFound("No messages found.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetMessagesBySender(int senderId)
        {
            try
            {
                var messages = await _messageService.GetMessagesBySenderAsync(senderId);
                if (!messages.Any())
                    return NotFound($"No messages found for sender ID {senderId}.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetMessagesByReceiver(int receiverId)
        {
            try
            {
                var messages = await _messageService.GetMessagesByReceiverAsync(receiverId);
                if (!messages.Any())
                    return NotFound($"No messages found for receiver ID {receiverId}.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
