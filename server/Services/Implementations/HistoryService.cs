using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly DataDapper _dataDapper;

        public HistoryService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<History>> GetHistoryAsync()
        {
            try
            {
                var sql = "SELECT * FROM History";
                return await _dataDapper.LoadDataAsync<History>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving history records: {ex.Message}", ex);
            }
        }

        public async Task<History?> GetHistoryByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM History WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<History>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving history record with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateHistoryAsync(History history)
        {
            try
            {
                string validationMessage = string.Empty;
                if (history == null || !history.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid history data: {validationMessage}");
                }

                var sql = @"INSERT INTO History (user_id, action, timestamp) 
                            VALUES (@UserId, @Action, @Timestamp)";

                return await _dataDapper.ExecuteSqlAsync(sql, history);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating history record: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteHistoryAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM History WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting history record with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
