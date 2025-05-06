using HelloWorld.Data;

public class GenderService : IGenderService
{
    private readonly DataDapper _dataDapper;

    public GenderService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<Gender>> GetAllAsync()
    {
        var sql = "SELECT * FROM Gender";
        return await _dataDapper.LoadDataAsync<Gender>(sql);
    }
}
