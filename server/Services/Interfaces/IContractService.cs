using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWorld.Models;

namespace HelloWorld.Services
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> GetContractsAsync();
        Task<Contract?> GetContractByIdAsync(int id);
        Task<bool> CreateContractAsync(Contract contract);
        Task<bool> UpdateContractAsync(int id, Contract contract);
        Task<bool> DeleteContractAsync(int id);
        Task<bool> CreateContractAsync(ContractCreateDto dto);
    }
}
