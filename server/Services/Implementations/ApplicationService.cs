using HelloWorld.Data;

public class ApplicationService : IApplicationService
{
    private readonly DataDapper _dataDapper;

    public ApplicationService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<ApplicationDetailsDto>> GetApplicationsAsync()
    {
        var sql = @"
        SELECT 
            a.id, 
            a.job_id AS JobId, 
            a.freelancer_id AS FreelancerId, 
            a.cover_letter AS CoverLetter, 
            a.date_applied AS DateApplied,
            j.job_title AS JobTitle, 
            f.skills AS Skills
        FROM Applications a
        LEFT JOIN JobInfo j ON a.job_id = j.id
        LEFT JOIN FreelancerProfile f ON a.freelancer_id = f.id";

        return await Task.Run(() =>
            _dataDapper.LoadData<ApplicationDetailsDto>(sql));
    }


    public async Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id)
    {
        var sql = @"
        SELECT 
            a.id, 
            a.job_id AS JobId, 
            a.freelancer_id AS FreelancerId, 
            a.cover_letter AS CoverLetter, 
            a.date_applied AS DateApplied,
            j.job_title AS JobTitle, 
            f.skills AS Skills
        FROM Applications a
        LEFT JOIN JobInfo j ON a.job_id = j.id
        LEFT JOIN FreelancerProfile f ON a.freelancer_id = f.id
        WHERE a.id = @Id";

        var result = await Task.Run(() =>
            _dataDapper.LoadDataSingle<ApplicationDetailsDto>(sql, new { Id = id }));

        if (result == null)
            throw new Exception($"Application with ID {id} not found.");

        return result;
    }


    public async Task<ApplicationDetailsDto?> CreateAndReturnAsync(Application application)
    {
        var sql = @"
            INSERT INTO Applications (job_id, freelancer_id, cover_letter, date_applied) 
            VALUES (@JobId, @FreelancerId, @CoverLetter, @DateApplied);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        var parameters = new
        {
            application.JobId,
            application.FreelancerId,
            application.CoverLetter,
            application.DateApplied
        };

        int newId = await Task.Run(() =>
            _dataDapper.LoadDataSingle<int>(sql, parameters));
        application.Id = newId;

        return await GetApplicationByIdAsync(newId);
    }

    public async Task<bool> UpdateApplicationAsync(int id, Application application)
    {
        var sql = @"
            UPDATE Applications SET 
                job_id = @JobId, 
                freelancer_id = @FreelancerId, 
                cover_letter = @CoverLetter, 
                date_applied = @DateApplied 
            WHERE id = @Id";

        return await _dataDapper.ExecuteSqlAsync(sql, new
        {
            Id = id,
            application.JobId,
            application.FreelancerId,
            application.CoverLetter,
            application.DateApplied
        });
    }

    public async Task<bool> DeleteApplicationAsync(int id)
    {
        var sql = "DELETE FROM Applications WHERE id = @Id";
        return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<Application>> GetByFreelancerIdAsync(int freelancerId)
    {
        var sql = "SELECT * FROM Applications WHERE freelancer_id = @FreelancerId";
        return await Task.Run(() =>
            _dataDapper.LoadData<Application>(sql, new { FreelancerId = freelancerId }));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var sql = "SELECT COUNT(1) FROM Applications WHERE id = @Id";
        var result = await Task.Run(() =>
            _dataDapper.LoadDataSingle<int>(sql, new { Id = id }));
        return result > 0;
    }
}
