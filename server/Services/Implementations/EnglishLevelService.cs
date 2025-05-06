using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class EnglishLevelService : IEnglishLevelService
    {
        private readonly DataDapper _dataDapper;

        public EnglishLevelService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<EnglishLevel> GetAllLevels()
        {
            string sql = "SELECT EnglishLevelID, EnglishLevelName FROM EnglishLevel";
            return _dataDapper.LoadData<EnglishLevel>(sql);
        }

        public EnglishLevel? GetLevelById(int id)
        {
            string sql = "SELECT EnglishLevelID, EnglishLevelName FROM EnglishLevel WHERE EnglishLevelID = @Id";
            return _dataDapper.LoadDataSingle<EnglishLevel>(sql, new { Id = id });
        }

        public bool AddLevel(EnglishLevel level)
        {
            string sql = "INSERT INTO EnglishLevel (EnglishLevelName) VALUES (@EnglishLevelName)";
            return _dataDapper.ExecuteSqlOpen(sql, level);
        }

        public bool UpdateLevel(EnglishLevel level)
        {
            string sql = "UPDATE EnglishLevel SET EnglishLevelName = @EnglishLevelName WHERE EnglishLevelID = @EnglishLevelID";
            return _dataDapper.ExecuteSqlOpen(sql, level);
        }

        public bool DeleteLevel(int id)
        {
            string sql = "DELETE FROM EnglishLevel WHERE EnglishLevelID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
