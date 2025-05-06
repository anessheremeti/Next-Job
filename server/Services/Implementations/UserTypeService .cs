using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly DataDapper _dataDapper;

        public UserTypeService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            var sql = "SELECT * FROM UserType";
            return await _dataDapper.LoadDataAsync<UserType>(sql);
        }

        public async Task<UserType?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM UserType WHERE UserTypeID = @Id";
            return await _dataDapper.LoadDataSingleAsync<UserType>(sql, new { Id = id });
        }

        public async Task<bool> CreateAsync(UserType userType)
        {
            var sql = "INSERT INTO UserType (UserTypeName) VALUES (@UserTypeName)";
            return await _dataDapper.ExecuteSqlAsync(sql, userType);
        }

        public async Task<bool> UpdateAsync(int id, UserType userType)
        {
            var sql = "UPDATE UserType SET UserTypeName = @UserTypeName WHERE UserTypeID = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { userType.UserTypeName, Id = id });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM UserType WHERE UserTypeID = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
        }
    }
}
