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
    }
}
