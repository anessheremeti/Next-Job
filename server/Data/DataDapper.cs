using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataDapper
    {
        private readonly string _connectionString;

        public DataDapper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Mungon 'DefaultConnection' në konfigurim.");
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(sql);
        }

        public IEnumerable<T> LoadData<T>(string sql, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(sql, parameters);
        }

        public T LoadDataSingle<T>(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<T>(sql);
        }

        public T? LoadDataSingle<T>(string sql, object? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                return connection.QuerySingleOrDefault<T>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në LoadDataSingle: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> LoadDataSingleAsync<T>(string sql, object? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në LoadDataSingleAsync: {ex.Message}");
                return default;
            }
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T>(string sql, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<T>(sql, parameters ?? new { });
        }

        public bool ExecuteSql(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRows(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Execute(sql);
        }

        public bool ExecuteSqlOpen(string sql, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                var result = connection.Execute(sql, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Dapper Error] SQL execution failed: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExecuteSqlAsync(string sql, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                var result = await connection.ExecuteAsync(sql, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Dapper ERROR] {ex.Message}");
                return false;
            }
        }
    }
}
