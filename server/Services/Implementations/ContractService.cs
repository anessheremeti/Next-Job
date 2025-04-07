using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class ContractService : IContractService
    {
        private readonly DataDapper _dataDapper;

        public ContractService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Contract>> GetContractsAsync()
        {
            try
            {
                var sql = "SELECT * FROM Contracts";
                return await _dataDapper.LoadDataAsync<Contract>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving contracts: {ex.Message}", ex);
            }
        }

        public async Task<Contract?> GetContractByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Contracts WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Contract>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving contract with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateContractAsync(Contract contract)
        {
            try
            {
                if (contract == null)
                {
                    throw new ArgumentException("Contract data is required.");
                }

                var sql = @"INSERT INTO Contracts (FreelancerId, ClientId, JobId, StartDate, EndDate, Status) 
                            VALUES (@FreelancerId, @ClientId, @JobId, @StartDate, @EndDate, @Status)";
                return await _dataDapper.ExecuteSqlAsync(sql, contract);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating contract: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateContractAsync(int id, Contract contract)
        {
            try
            {
                if (contract == null || id != contract.Id)
                {
                    throw new ArgumentException("Invalid contract data.");
                }

                var sql = @"UPDATE Contracts 
                            SET FreelancerId = @FreelancerId, ClientId = @ClientId, JobId = @JobId, StartDate = @StartDate, 
                                EndDate = @EndDate, Status = @Status 
                            WHERE Id = @Id";
                contract.Id = id;
                return await _dataDapper.ExecuteSqlAsync(sql, contract);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating contract with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteContractAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Contracts WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting contract with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
