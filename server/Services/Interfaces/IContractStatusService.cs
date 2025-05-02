public interface IContractStatusService
{
    Task<IEnumerable<ContractStatus>> GetAllAsync();
}
