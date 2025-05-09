using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly DataDapper _dataDapper;

    public UserService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var sql = @"SELECT u.id,
            u.user_type_id AS UserTypeId,
            u.full_name AS FullName,
            u.company_name AS CompanyName,
            u.email,
            u.password_hash,
            u.created_at,
            ut.UserTypeName AS UserTypeName
        FROM Users u
        LEFT JOIN UserType ut ON u.user_type_id = ut.UserTypeID
        ";

        return await _dataDapper.LoadDataAsync<User>(sql);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
                var sql = @"SELECT u.id,
            u.user_type_id AS UserTypeId,
            u.full_name AS FullName,
            u.company_name AS CompanyName,
            u.email,
            u.password_hash,
            u.created_at,
            ut.UserTypeName AS UserTypeName
        FROM Users u
        LEFT JOIN UserType ut ON u.user_type_id = ut.UserTypeID
        WHERE u.id = @Id
        ";

        return await _dataDapper.LoadDataSingleAsync<User>(sql, new { Id = id });
    }

    public async Task<bool> CreateUserAsync(User user, string plainPassword)
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

        if (string.IsNullOrWhiteSpace(user.FullName))
        {
            user.FullName = "Unknown Name";
        }
        if (string.IsNullOrWhiteSpace(user.CompanyName))
        {
            user.CompanyName = "Unknown Company";
        }

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



    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        if (id != user.Id)
            throw new ArgumentException("Mismatched user ID.");

        if (!user.IsValid(out string validationMessage))
            throw new ArgumentException($"Invalid user data: {validationMessage}");

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
        var sql = "DELETE FROM Users WHERE id = @Id";
        return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
    }
}
