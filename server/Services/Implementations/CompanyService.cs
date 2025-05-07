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
                var sql = "SELECT * FROM Company WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<Company>(sql, new { Id = id });
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
                if (company == null)
                    throw new ArgumentNullException(nameof(company), "Company object is null.");

                if (!company.IsValid(out var validationMessage))
                    throw new ArgumentException("Invalid company data. " + (validationMessage ?? "Unknown validation error."));

                var sql = @"
            INSERT INTO Company (owner_id, name, description, website, created_at) 
            VALUES (@OwnerId, @Name, @Description, @Website, @CreatedAt)";

                return await _dataDapper.ExecuteSqlAsync(sql, company);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to insert company: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> UpdateCompanyAsync(int id, Company company)
        {
            try
            {
                if (company == null)
                    throw new ArgumentNullException(nameof(company), "Company object is null.");

                if (id != company.Id)
                    throw new ArgumentException("ID mismatch between parameter and company object.");

                if (!company.IsValid(out var validationMessage))
                    throw new ArgumentException("Invalid company data. " + (validationMessage ?? "Unknown validation error."));

                var sql = @"
            UPDATE Company 
            SET owner_id = @OwnerId, 
                name = @Name, 
                description = @Description, 
                website = @Website, 
                created_at = @CreatedAt 
            WHERE id = @Id";

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
                var sql = "DELETE FROM Company WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting company with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
