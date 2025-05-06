using HelloWorld.Data;

public class JobTypeService : IJobTypeService
{
    private readonly DataDapper _dataDapper;

    public JobTypeService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<JobType>> GetAllAsync()
    {
        var sql = "SELECT * FROM JobType";
        return await _dataDapper.LoadDataAsync<JobType>(sql);
    }
}
