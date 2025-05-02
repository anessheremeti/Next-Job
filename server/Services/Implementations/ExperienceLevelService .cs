using HelloWorld.Data;

public class ExperienceLevelService : IExperienceLevelService
{
    private readonly DataDapper _dataDapper;

    public ExperienceLevelService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<ExperienceLevel>> GetAllAsync()
    {
        var sql = "SELECT * FROM ExperienceLevel";
        return await _dataDapper.LoadDataAsync<ExperienceLevel>(sql);
    }
}
