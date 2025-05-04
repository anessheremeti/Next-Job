using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
            var sql = @"SELECT u.id, u.user_type_id AS UserTypeId, u.full_name, u.company_name, 
                               u.email, u.password_hash, u.created_at,
                               ut.UserTypeName AS UserTypeName
                        FROM Users u
                        LEFT JOIN UserType ut ON u.user_type_id = ut.UserTypeID";

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
            var sql = @"SELECT u.id, u.user_type_id AS UserTypeId, u.full_name, u.company_name, 
                               u.email, u.password_hash, u.created_at,
                               ut.UserTypeName AS UserTypeName
                        FROM Users u
                        LEFT JOIN UserType ut ON u.user_type_id = ut.UserTypeID
                        WHERE u.id = @Id";

            return await _dataDapper.LoadDataSingleAsync<User>(sql, new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while retrieving user with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<bool> CreateUserAsync(User user, string plainPassword)
    {
        try
        {
            if (user == null)
                throw new ArgumentException("User data is required.");

            if (!user.IsValid(out string validationMessage))
                throw new ArgumentException($"Invalid user data: {validationMessage}");

            var userTypeExists = await _dataDapper.LoadDataSingleAsync<int>(
                "SELECT COUNT(1) FROM UserType WHERE UserTypeID = @Id", new { Id = user.UserTypeId });

            if (userTypeExists == 0)
                throw new ArgumentException("Invalid UserTypeId: does not exist.");

            var existingUser = await _dataDapper.LoadDataSingleAsync<User>(
                "SELECT * FROM Users WHERE email = @Email", new { user.Email });

            if (existingUser != null)
                throw new InvalidOperationException("Email already in use.");

            user.SetPassword(plainPassword);
            user.CreatedAt = DateTime.Now;

            var sql = @"INSERT INTO Users (user_type_id, full_name, company_name, email, password_hash, created_at)
                        VALUES (@UserTypeId, @FullName, @CompanyName, @Email, @PasswordHash, @CreatedAt)";

            var parameters = new
            {
                user.UserTypeId,
                user.FullName,
                user.CompanyName,
                user.Email,
                user.PasswordHash,
                user.CreatedAt
            };

            return await _dataDapper.ExecuteSqlAsync(sql, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while creating user: {ex.Message}", ex);
        }
    }
}
