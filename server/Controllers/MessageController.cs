using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
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

<<<<<<< HEAD
        // GET: api/message
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _messageService.GetMessagesAsync();
<<<<<<< HEAD
                if (messages == null || !messages.Any())
=======

                if (!messages.Any())
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
                    return NotFound("No messages found.");

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

<<<<<<< HEAD
        // GET: api/message/{id}
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
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

<<<<<<< HEAD
        // GET: api/message/sender/{senderId}
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetMessagesBySender(int senderId)
        {
            try
            {
                var messages = await _messageService.GetMessagesBySenderAsync(senderId);
<<<<<<< HEAD
=======
                if (!messages.Any())
                    return NotFound($"No messages found for sender ID {senderId}.");

>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

<<<<<<< HEAD
        // GET: api/message/receiver/{receiverId}
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetMessagesByReceiver(int receiverId)
        {
            try
            {
                var messages = await _messageService.GetMessagesByReceiverAsync(receiverId);
<<<<<<< HEAD
=======
                if (!messages.Any())
                    return NotFound($"No messages found for receiver ID {receiverId}.");

>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving messages: {ex.Message}");
            }
        }

<<<<<<< HEAD
        // POST: api/message
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            try
            {
                if (message == null)
                    return BadRequest("Message data is required.");

<<<<<<< HEAD
                if (!message.IsValid(out string validationMessage))
                    return BadRequest(validationMessage);

                var isCreated = await _messageService.CreateMessageAsync(message);
                if (!isCreated)
=======
                if (!message.IsValid(out var validationMessage))
                    return BadRequest(validationMessage);

                var created = await _messageService.CreateMessageAsync(message);
                if (!created)
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
                    return StatusCode(500, "Failed to create message.");

                return Ok("Message created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating message: {ex.Message}");
            }
        }

<<<<<<< HEAD
        // DELETE: api/message/{id}
=======
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
<<<<<<< HEAD
                var isDeleted = await _messageService.DeleteMessageAsync(id);
                if (!isDeleted)
=======
                var deleted = await _messageService.DeleteMessageAsync(id);
                if (!deleted)
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
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
