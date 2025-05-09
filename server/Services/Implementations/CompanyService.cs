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
                var sql = @"
                SELECT 
                    c.id, c.owner_id AS OwnerId, c.name, c.description, c.website, c.created_at AS CreatedAt,
                    u.id, u.full_name, u.email
                FROM Company c
                LEFT JOIN [Users] u ON c.owner_id = u.id
            ";


                return await _dataDapper.LoadDataWithJoinAsync<Company, User>(
                    sql,
                    (company, owner) =>
                    {
                        company.Owner = owner;
                        return company;
                    },
                    splitOn: "OwnerId"
                );
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
                var sql = @"
                    SELECT 
                        c.id, c.owner_id AS OwnerId, c.name, c.description, c.website, c.created_at AS CreatedAt,
                        u.id,
                        u.user_type_id AS UserTypeId,
                        u.full_name AS FullName,
                        u.company_name AS CompanyName,
                        u.email,
                        u.password_hash AS PasswordHash,
                        u.created_at AS CreatedAt
                    FROM Company c
                    LEFT JOIN [Users] u ON c.owner_id = u.id
                ";


                return await _dataDapper.LoadDataSingleWithJoinAsync<Company, User>(
                    sql,
                    (company, owner) =>
                    {
                        company.Owner = owner;
                        return company;
                    },
                    new { Id = id },
                    splitOn: "OwnerId"
                );
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
