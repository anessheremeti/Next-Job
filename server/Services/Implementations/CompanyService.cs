using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataDapper _dataDapper;

        public CompanyService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            try
            {
                var sql = "SELECT * FROM Company";
                return await _dataDapper.LoadDataAsync<Company>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving companies: {ex.Message}", ex);
            }
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Company WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Company>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving company with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateCompanyAsync(Company company)
        {
            try
            {
<<<<<<< HEAD
                string validationMessage = string.Empty; 
                if (company == null || !company.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid company data: {validationMessage}");
                }

                var sql = @"INSERT INTO Company (OwnerId, Name, Description, Website, CreatedAt) 
=======
                string sql = @"INSERT INTO Company (owner_id, name, description, website, created_at)
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
                            VALUES (@OwnerId, @Name, @Description, @Website, @CreatedAt)";

                return await _dataDapper.ExecuteSqlAsync(sql, company);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error inserting company: " + ex.Message);
                throw; 
            }
            
        }


        public async Task<bool> UpdateCompanyAsync(int id, Company company)
        {
            try
            {
                string validationMessage = string.Empty;
                if (company == null || id != company.Id || !company.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid company data: {validationMessage}");
                }


                var sql = @"UPDATE Company 
                            SET OwnerId = @OwnerId, 
                                Name = @Name, 
                                Description = @Description, 
                                Website = @Website, 
                                CreatedAt = @CreatedAt 
                            WHERE Id = @Id";

                return await _dataDapper.ExecuteSqlAsync(sql, company);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating company with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Company WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting company with ID {id}: {ex.Message}", ex);
            }
        }
        
    }
}
