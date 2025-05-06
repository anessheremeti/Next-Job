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
<<<<<<< HEAD
            try
            {
                var sql = "SELECT * FROM Messages";
                return await _dataDapper.LoadDataAsync<Message>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages: {ex.Message}", ex);
            }
=======
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages";
            return await _dataDapper.LoadDataAsync<Message>(sql);
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
<<<<<<< HEAD
            try
            {
                var sql = "SELECT * FROM Messages WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<Message>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving message with ID {id}: {ex.Message}", ex);
            }
=======
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE id = @Id";
            return await _dataDapper.LoadDataSingleAsync<Message>(sql, new { Id = id });
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }

        public async Task<IEnumerable<Message>> GetMessagesBySenderAsync(int senderId)
        {
<<<<<<< HEAD
            try
            {
                var sql = "SELECT * FROM Messages WHERE sender_id = @SenderId";
                return await _dataDapper.LoadDataAsync<Message>(sql, new { SenderId = senderId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages for sender ID {senderId}: {ex.Message}", ex);
            }
=======
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE sender_id = @SenderId";
            return await _dataDapper.LoadDataAsync<Message>(sql, new { SenderId = senderId });
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }

        public async Task<IEnumerable<Message>> GetMessagesByReceiverAsync(int receiverId)
        {
<<<<<<< HEAD
            try
            {
                var sql = "SELECT * FROM Messages WHERE receiver_id = @ReceiverId";
                return await _dataDapper.LoadDataAsync<Message>(sql, new { ReceiverId = receiverId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving messages for receiver ID {receiverId}: {ex.Message}", ex);
            }
=======
            var sql = @"SELECT 
                            id AS Id,
                            sender_id AS SenderId,
                            receiver_id AS ReceiverId,
                            message AS MessageContent,
                            date_time AS DateTime
                        FROM Messages
                        WHERE receiver_id = @ReceiverId";
            return await _dataDapper.LoadDataAsync<Message>(sql, new { ReceiverId = receiverId });
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }

        public async Task<bool> CreateMessageAsync(Message message)
        {
            if (message == null)
                throw new ArgumentException("Message data is required.");

<<<<<<< HEAD
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
=======
            var sql = @"INSERT INTO Messages (sender_id, receiver_id, message, date_time)
                        VALUES (@SenderId, @ReceiverId, @MessageContent, @DateTime)";

            return await _dataDapper.ExecuteSqlAsync(sql, message);
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
<<<<<<< HEAD
            try
            {
                var sql = "DELETE FROM Messages WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting message with ID {id}: {ex.Message}", ex);
            }
=======
            var sql = "DELETE FROM Messages WHERE id = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
>>>>>>> 3097074f4bd1c3b7fbde8311ae194bae723ca109
        }
    }
}
