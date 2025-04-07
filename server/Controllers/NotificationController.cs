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
            try
            {
                var notifications = await _notificationService.GetNotificationsAsync();

                if (notifications == null || !notifications.Any())
                {
                    return NotFound("No notifications found.");
                }

                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/notification/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            try
            {
                var notification = await _notificationService.GetNotificationByIdAsync(id);

                if (notification == null)
                {
                    return NotFound($"Notification with ID {id} not found.");
                }

                return Ok(notification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/notification/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetNotificationsByUser(int userId)
        {
            try
            {
                var notifications = await _notificationService.GetNotificationsByUserAsync(userId);

                if (notifications == null || !notifications.Any())
                {
                    return NotFound($"No notifications found for user ID {userId}.");
                }

                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/notification
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
        {
            try
            {
                if (notification == null)
                {
                    return BadRequest("Notification data is required.");
                }

                // Validate notification data
                string validationMessage;
                if (!notification.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var isCreated = await _notificationService.CreateNotificationAsync(notification);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create notification.");
                }

                return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/notification/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            try
            {
                var isUpdated = await _notificationService.MarkAsReadAsync(id);

                if (!isUpdated)
                {
                    return NotFound($"Notification with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/notification/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                var isDeleted = await _notificationService.DeleteNotificationAsync(id);

                if (!isDeleted)
                {
                    return NotFound($"Notification with ID {id} not found.");
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

