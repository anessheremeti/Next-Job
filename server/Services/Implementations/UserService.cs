using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class UserService : IUserService
    {
        private readonly DataDapper _dataDapper;

        public UserService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var sql = "SELECT * FROM Users";
            return await _dataDapper.LoadDataAsync<User>(sql);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            return await _dataDapper.LoadDataSingleAsync<User>(sql, new { Id = id });
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (!user.IsValid(out string validationMessage))
            {
                throw new ArgumentException($"Invalid user data: {validationMessage}");
            }

            var sql = @"INSERT INTO Users (user_type_id, full_name, company_name, email, password_hash, created_at)
                        VALUES (@UserTypeId, @FullName, @CompanyName, @Email, @PasswordHash, @CreatedAt)";

            return await _dataDapper.ExecuteSqlAsync(sql, user);
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            if (id != user.Id)
            {
                throw new ArgumentException("Mismatched user ID.");
            }

            if (!user.IsValid(out string validationMessage))
            {
                throw new ArgumentException($"Invalid user data: {validationMessage}");
            }

            var sql = @"UPDATE Users SET 
                            user_type_id = @UserTypeId,
                            full_name = @FullName,
                            company_name = @CompanyName,
                            email = @Email,
                            password_hash = @PasswordHash,
                            created_at = @CreatedAt
                        WHERE id = @Id";

            return await _dataDapper.ExecuteSqlAsync(sql, user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
        }
    }
}
