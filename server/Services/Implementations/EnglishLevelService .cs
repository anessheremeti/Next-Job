using HelloWorld.Data;

public class EnglishLevelService : IEnglishLevelService
{
    private readonly DataDapper _dataDapper;

    public EnglishLevelService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<EnglishLevel>> GetAllAsync()
    {
        var sql = "SELECT * FROM EnglishLevel";
        return await _dataDapper.LoadDataAsync<EnglishLevel>(sql);
    }
}
