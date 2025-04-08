using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task<IEnumerable<Message>> GetMessagesBySenderAsync(int senderId);
        Task<IEnumerable<Message>> GetMessagesByReceiverAsync(int receiverId);
        Task<bool> CreateMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(int id);
    }
}
