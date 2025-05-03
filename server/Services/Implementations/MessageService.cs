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
                var sql = "SELECT * FROM Message";
                return await _dataDapper.LoadDataAsync<Message>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving message records: {ex.Message}", ex);
            }
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Message WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Message>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving message record with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesBySenderAsync(int senderId)
        {
            try
            {
                var sql = "SELECT * FROM Message WHERE SenderId = @SenderId";
                var parameters = new { SenderId = senderId };
                return await _dataDapper.LoadDataAsync<Message>(sql, parameters);
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
                var sql = "SELECT * FROM Message WHERE ReceiverId = @ReceiverId";
                var parameters = new { ReceiverId = receiverId };
                return await _dataDapper.LoadDataAsync<Message>(sql, parameters);
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

                var sql = "INSERT INTO Message (SenderId, ReceiverId, MessageContent, DateTime) " +
                          "VALUES (@SenderId, @ReceiverId, @MessageContent, @DateTime)";

                return await _dataDapper.ExecuteSqlAsync(sql, message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating message record: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Message WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting message record with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
