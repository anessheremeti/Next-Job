using HelloWorld.Data;
using HelloWorld.Models;
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
                var sql = "SELECT * FROM Contracts WHERE id = @Id";
                return await _dataDapper.LoadDataSingleAsync<Contract>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving contract with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateContractAsync(ContractCreateDto dto)
        {
            try
            {
                if (dto == null)
                    throw new ArgumentException("Contract data is required.");

                var contract = new Contract
                {
                    FreelancerId = dto.FreelancerId,
                    ClientId = dto.ClientId,
                    JobId = dto.JobId,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    ContractStatusId = dto.ContractStatusId
                };

                if (!contract.IsValid(out var validationMessage))
                    throw new ArgumentException($"Invalid contract data. {validationMessage}");

                var sql = @"
                    INSERT INTO Contracts (freelancer_id, client_id, job_id, start_date, end_date, contract_status_id) 
                    VALUES (@FreelancerId, @ClientId, @JobId, @StartDate, @EndDate, @ContractStatusId)";

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
                if (contract == null)
                    throw new ArgumentException("Contract object is null.");

                if (id != contract.Id)
                    throw new ArgumentException("Mismatched contract ID.");

                string validationMessage;
                if (!contract.IsValid(out validationMessage))
                    throw new ArgumentException("Invalid contract data: " + validationMessage);

                var sql = @"
            UPDATE Contracts 
            SET freelancer_id = @FreelancerId, 
                client_id = @ClientId, 
                job_id = @JobId, 
                start_date = @StartDate, 
                end_date = @EndDate, 
                contract_status_id = @ContractStatusId 
            WHERE id = @Id";

                var parameters = new
                {
                    contract.FreelancerId,
                    contract.ClientId,
                    contract.JobId,
                    contract.StartDate,
                    contract.EndDate,
                    contract.ContractStatusId,
                    Id = id
                };

                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
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
                var sql = "DELETE FROM Contracts WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting contract with ID {id}: {ex.Message}", ex);
            }
        }

        public Task<bool> CreateContractAsync(Contract contract)
        {
            throw new NotImplementedException();
        }
    }
}
