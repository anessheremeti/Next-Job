using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly DataDapper _dataDapper;

        public UserTypeService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<UserType>> GetUserTypesAsync()
        {
            var sql = "SELECT * FROM UserType";
            return await _dataDapper.LoadDataAsync<UserType>(sql);
        }

        public async Task<UserType?> GetUserTypeByIdAsync(int id)
        {
            var sql = "SELECT * FROM UserType WHERE UserTypeId = @Id";
            return await _dataDapper.LoadDataSingleAsync<UserType>(sql, new { Id = id });
        }

        public async Task<bool> CreateUserTypeAsync(UserType userType)
        {
            var sql = "INSERT INTO UserType (UserTypeName) VALUES (@UserTypeName)";
            return await _dataDapper.ExecuteSqlAsync(sql, userType);
        }

        public async Task<bool> UpdateUserTypeAsync(int id, UserType userType)
        {
            if (id != userType.UserTypeId) return false;

            var sql = "UPDATE UserType SET UserTypeName = @UserTypeName WHERE UserTypeId = @UserTypeId";
            return await _dataDapper.ExecuteSqlAsync(sql, userType);
        }

        public async Task<bool> DeleteUserTypeAsync(int id)
        {
            var sql = "DELETE FROM UserType WHERE UserTypeId = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
        }
    }
}
