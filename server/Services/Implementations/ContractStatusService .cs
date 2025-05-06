using HelloWorld.Data;

public class ContractStatusService : IContractStatusService
{
    private readonly DataDapper _dataDapper;

    public ContractStatusService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<ContractStatus>> GetAllAsync()
    {
        var sql = "SELECT * FROM ContractStatus";
        return await _dataDapper.LoadDataAsync<ContractStatus>(sql);
    }
}
