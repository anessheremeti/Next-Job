using System;
using System.Data;
using System.Net.WebSockets;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace HelloWorld.Data
{
    public class DataDapper
    {


        private string _connectionString = "";
        public DataDapper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Mungon 'DefaultConnection' ");

        }


        //Kjo osht metoda Query e dapper edhe na ndihmon qe mos me shkru shume here ne qdo klas por vetem ne kete klas edhe tane e thirrmi
        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        //Kjo osht metoda QuerySingle e Dapper
        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        //Kjo osht metoda execute por nuk i numron rreshtat
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return (dbConnection.Execute(sql) > 0);
        }

        //Kjo osht metoda execute e cila inumron rreshtat
        public int ExecuteSqlWithRows(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }

        /*
            Pra keto te 3 jan metodat kryesore te Dapper 

            QuerySingle => kthen vetem nje rresht nga databaza nga te dhenat
            Query => kthen te dhena ne shume rreshta te tipit IENumberable
            Execute => perdoret per te shtuar,fshir,krijuar,edituar te dhena        
        */

        public async Task<bool> ExecuteSqlAsync(string sql, object parameters)
        {
            try
            {
                using (var dbConnection = new SqlConnection(_connectionString))
                {
                    await dbConnection.OpenAsync();
                    var result = await dbConnection.ExecuteAsync(sql, parameters);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ExecuteSqlOpen(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    var result = dbConnection.Execute(sql, parameters);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public T? LoadDataSingle<T>(string sql, object? parameters = null)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    return dbConnection.QuerySingleOrDefault<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në LoadDataSingle: {ex.Message}");
                return default(T);
            }
        }


        public async Task<IEnumerable<T>> LoadDataAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<T>(sql, parameters ?? new { });
            }
        }
        public async Task<T?> LoadDataSingleAsync<T>(string sql, object? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në LoadDataSingle: {ex.Message}");
                return default(T);
            }
        }
        public async Task<T?> LoadDataSingleFromDatabase<T>(string sql, object parameters)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në LoadDataSingle: {ex.Message}");
                return default(T);
            }
        }



    }
}
