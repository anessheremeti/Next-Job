using HelloWorld.Data;

public class BudgetTypeService : IBudgetTypeService
{
    private readonly DataDapper _dataDapper;

    public BudgetTypeService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<BudgetType>> GetAllAsync()
    {
        var sql = "SELECT * FROM BudgetType";
        return await _dataDapper.LoadDataAsync<BudgetType>(sql);
    }
}
