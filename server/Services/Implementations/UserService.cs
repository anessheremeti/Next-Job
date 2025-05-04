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
            try
            {
                var sql = "SELECT * FROM Users";
                return await _dataDapper.LoadDataAsync<User>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving users: {ex.Message}", ex);
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Users WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<User>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving user with ID {id}: {ex.Message}", ex);
            }
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentException("User data is required.");
                }

                var sql = @"INSERT INTO Users (user_type_id, full_name, company_name, email, password_hash, created_at)
            VALUES (@UserTypeId, @FullName, @CompanyName, @Email, @PasswordHash, @CreatedAt)";

            var parameters = new
            {
                UserTypeId = user.UserTypeId,
                FullName = user.FullName,
                CompanyName = user.CompanyName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreatedAt = user.CreatedAt
            };

                var result = await _dataDapper.ExecuteSqlAsync(sql, parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating user: {ex.Message}", ex);
            }
        }


    }
}
