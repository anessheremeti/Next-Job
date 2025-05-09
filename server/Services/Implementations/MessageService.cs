using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class MessageService : IMessageService
    {
        private readonly DataDapper _dataDapper;

        public MessageService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages";
            return await _dataDapper.LoadDataAsync<Message>(sql);
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE id = @Id";
            return await _dataDapper.LoadDataSingleAsync<Message>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Message>> GetMessagesBySenderAsync(int senderId)
        {
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE sender_id = @SenderId";
            return await _dataDapper.LoadDataAsync<Message>(sql, new { SenderId = senderId });
        }

        public async Task<IEnumerable<Message>> GetMessagesByReceiverAsync(int receiverId)
        {
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE receiver_id = @ReceiverId";
            return await _dataDapper.LoadDataAsync<Message>(sql, new { ReceiverId = receiverId });
        }

        public async Task<bool> CreateMessageAsync(Message message)
        {
            if (message == null)
                throw new ArgumentException("Message data is required.");

            if (!message.IsValid(out string validationMessage))
                throw new ArgumentException($"Validation failed: {validationMessage}");

            var sql = @"INSERT INTO Messages (sender_id, receiver_id, message, date_time)
                        VALUES (@SenderId, @ReceiverId, @MessageContent, @DateTime)";

            return await _dataDapper.ExecuteSqlAsync(sql, message);
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var sql = "DELETE FROM Messages WHERE id = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
        }
    }
}
