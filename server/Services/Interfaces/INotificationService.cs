using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<Notification?> GetNotificationByIdAsync(int id);
        Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId);
        Task<bool> CreateNotificationAsync(Notification notification);
        Task<bool> MarkAsReadAsync(int id);
        Task<bool> DeleteNotificationAsync(int id);
    }
}
