<<<<<<< HEAD
public interface IContractStatusService
{
    Task<IEnumerable<ContractStatus>> GetAllAsync();
=======
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
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
