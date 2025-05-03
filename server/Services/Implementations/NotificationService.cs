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
                var sql = "SELECT * FROM Notification";
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
                var sql = "SELECT * FROM Notification WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Notification>(sql, parameters);
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
                var sql = "SELECT * FROM Notification WHERE UserId = @UserId";
                var parameters = new { UserId = userId };
                return await _dataDapper.LoadDataAsync<Notification>(sql, parameters);
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
                if (notification == null)
                {
                    throw new ArgumentException("Notification data is required.");
                }

                var sql = "INSERT INTO Notification (UserId, Message, IsRead, CreatedAt) " +
                          "VALUES (@UserId, @Message, @IsRead, @CreatedAt)";
                
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
                var sql = "UPDATE Notification SET IsRead = 1 WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
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
                var sql = "DELETE FROM Notification WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting notification with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
