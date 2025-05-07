
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IContractStatusService
    {
        IEnumerable<ContractStatus> GetAllStatuses();
        ContractStatus? GetStatusById(int id);
        bool AddStatus(ContractStatus status);
        bool UpdateStatus(ContractStatus status);
        bool DeleteStatus(int id);
    }
}
