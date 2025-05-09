using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class NotificationService : INotificationService
    {
        private readonly DataDapper _dataDapper;

        public NotificationService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            try
            {
                var sql = "SELECT * FROM Notifications";
                return await _dataDapper.LoadDataAsync<Notification>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving notifications: {ex.Message}", ex);
            }
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Notifications WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<Notification>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving notification with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId)
        {
            try
            {
                var sql = "SELECT * FROM Notifications WHERE user_id = @UserId";
                return await _dataDapper.LoadDataAsync<Notification>(sql, new { UserId = userId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving notifications for user ID {userId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateNotificationAsync(Notification notification)
        {
            try
            {
                string validationMessage;
                if (!notification.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid notification data: {validationMessage}");
                }


                var sql = @"
                    INSERT INTO Notifications (user_id, message, is_read, created_at)
                    VALUES (@UserId, @Message, @IsRead, @CreatedAt)";

                return await _dataDapper.ExecuteSqlAsync(sql, notification);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating notification: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAsReadAsync(int id)
        {
            try
            {
                var sql = "UPDATE Notifications SET is_read = 1 WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while marking notification with ID {id} as read: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Notifications WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting notification with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
