using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class GenderService : IGenderService
    {
        private readonly DataDapper _dataDapper;

        public GenderService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            string sql = "SELECT GenderID, GenderName FROM Gender";
            return _dataDapper.LoadData<Gender>(sql);
        }

        public Gender? GetGenderById(int id)
        {
            string sql = "SELECT GenderID, GenderName FROM Gender WHERE GenderID = @Id";
            return _dataDapper.LoadDataSingle<Gender>(sql, new { Id = id });
        }

        public bool AddGender(Gender gender)
        {
            string sql = "INSERT INTO Gender (GenderName) VALUES (@GenderName)";
            return _dataDapper.ExecuteSqlOpen(sql, gender);
        }

        public bool UpdateGender(Gender gender)
        {
            string sql = "UPDATE Gender SET GenderName = @GenderName WHERE GenderID = @GenderID";
            return _dataDapper.ExecuteSqlOpen(sql, gender);
        }

        public bool DeleteGender(int id)
        {
            string sql = "DELETE FROM Gender WHERE GenderID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
