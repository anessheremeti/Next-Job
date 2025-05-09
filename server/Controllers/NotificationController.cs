using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET api/notification
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _notificationService.GetNotificationsAsync();
            if (notifications == null || !notifications.Any())
                return NotFound("No notifications found.");

            return Ok(notifications);
        }

        // GET api/notification/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
                return NotFound($"Notification with ID {id} not found.");

            return Ok(notification);
        }

        // GET api/notification/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetNotificationsByUser(int userId)
        {
            var notifications = await _notificationService.GetNotificationsByUserAsync(userId);
            if (notifications == null || !notifications.Any())
                return NotFound($"No notifications found for user ID {userId}.");

            return Ok(notifications);
        }

        // POST api/notification
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
        {
            if (notification == null)
                return BadRequest("Notification data is required.");

            string validationMessage;
            if (!notification.IsValid(out validationMessage))
                return BadRequest(validationMessage);

            var isCreated = await _notificationService.CreateNotificationAsync(notification);
            if (!isCreated)
                return StatusCode(500, "Failed to create notification.");

            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
        }

        // PUT api/notification/markasread/{id}
        [HttpPut("markasread/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var isMarked = await _notificationService.MarkAsReadAsync(id);
            if (!isMarked)
                return NotFound($"Notification with ID {id} not found.");

            return NoContent();
        }

        // DELETE api/notification/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var isDeleted = await _notificationService.DeleteNotificationAsync(id);
            if (!isDeleted)
                return NotFound($"Notification with ID {id} not found.");

            return NoContent();
        }
    }
}
