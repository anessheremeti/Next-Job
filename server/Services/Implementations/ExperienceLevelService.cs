using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class ExperienceLevelService : IExperienceLevelService
    {
        private readonly DataDapper _dataDapper;

        public ExperienceLevelService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<ExperienceLevel> GetAllExperienceLevels()
        {
            string sql = "SELECT ExperienceLevelID, ExperienceLevelName FROM ExperienceLevel";
            return _dataDapper.LoadData<ExperienceLevel>(sql);
        }

        public ExperienceLevel? GetExperienceLevelById(int id)
        {
            string sql = "SELECT ExperienceLevelID, ExperienceLevelName FROM ExperienceLevel WHERE ExperienceLevelID = @Id";
            return _dataDapper.LoadDataSingle<ExperienceLevel>(sql, new { Id = id });
        }

        public bool AddExperienceLevel(ExperienceLevel level)
        {
            string sql = "INSERT INTO ExperienceLevel (ExperienceLevelName) VALUES (@ExperienceLevelName)";
            return _dataDapper.ExecuteSqlOpen(sql, level);
        }

        public bool UpdateExperienceLevel(ExperienceLevel level)
        {
            string sql = "UPDATE ExperienceLevel SET ExperienceLevelName = @ExperienceLevelName WHERE ExperienceLevelID = @ExperienceLevelID";
            return _dataDapper.ExecuteSqlOpen(sql, level);
        }

        public bool DeleteExperienceLevel(int id)
        {
            string sql = "DELETE FROM ExperienceLevel WHERE ExperienceLevelID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
