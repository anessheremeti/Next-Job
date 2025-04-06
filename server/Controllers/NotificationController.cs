using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public NotificationController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/notification
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var sql = "SELECT * FROM Notification";

                var notifications = await Task.Run(() => _dataDapper.LoadData<Notification>(sql));

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
                var sql = $"SELECT * FROM Notification WHERE Id = {id}";

                var notification = await Task.Run(() => _dataDapper.LoadDataSingle<Notification>(sql));

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
                var sql = $"SELECT * FROM Notification WHERE UserId = {userId}";

                var notifications = await Task.Run(() => _dataDapper.LoadData<Notification>(sql));

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
        public IActionResult CreateNotification([FromBody] Notification notification)
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

                var sql = $"INSERT INTO Notification (UserId, Message, IsRead, CreatedAt) " +
                          $"VALUES ({notification.UserId}, '{notification.Message}', {notification.IsRead}, '{notification.CreatedAt}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult MarkAsRead(int id)
        {
            try
            {
                var sql = $"UPDATE Notification SET IsRead = 1 WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult DeleteNotification(int id)
        {
            try
            {
                var sql = $"DELETE FROM Notification WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

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
