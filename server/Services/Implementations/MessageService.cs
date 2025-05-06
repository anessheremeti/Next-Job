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
            try
            {
                var sql = "SELECT * FROM Messages";
                return await _dataDapper.LoadDataAsync<Message>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages: {ex.Message}", ex);
            }
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Messages WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<Message>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving message with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesBySenderAsync(int senderId)
        {
            try
            {
                var sql = "SELECT * FROM Messages WHERE sender_id = @SenderId";
                return await _dataDapper.LoadDataAsync<Message>(sql, new { SenderId = senderId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages for sender ID {senderId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesByReceiverAsync(int receiverId)
        {
            try
            {
                var sql = "SELECT * FROM Messages WHERE receiver_id = @ReceiverId";
                return await _dataDapper.LoadDataAsync<Message>(sql, new { ReceiverId = receiverId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages for receiver ID {receiverId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateMessageAsync(Message message)
        {
            try
            {
                if (message == null)
                {
                    throw new ArgumentException("Message data is required.");
                }

                if (!message.IsValid(out string validationMessage))
                {
                    throw new ArgumentException($"Validation failed: {validationMessage}");
                }

                var sql = @"
                    INSERT INTO Messages (sender_id, receiver_id, message, date_time)
                    VALUES (@SenderId, @ReceiverId, @MessageContent, @DateTime)";

                return await _dataDapper.ExecuteSqlAsync(sql, message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating message: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Messages WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting message with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
