    using HelloWorld.Data;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace HelloWorld.Services
    {
        public class ApplicationService : IApplicationService
        {
            private readonly DataDapper _dataDapper;

            public ApplicationService(DataDapper dataDapper)
            {
                _dataDapper = dataDapper;
            }

            public async Task<IEnumerable<Application>> GetApplicationsAsync()
            {
                var sql = "SELECT * FROM Applications";
                return await Task.Run(() => _dataDapper.LoadData<Application>(sql));
            }

            public async Task<Application> GetApplicationByIdAsync(int id)
            {
                var sql = $"SELECT * FROM Applications WHERE Id = {id}";
                return await Task.Run(() => _dataDapper.LoadDataSingle<Application>(sql));
            }

            public async Task<bool> CreateApplicationAsync(Application application)
            {
                var sql = @"INSERT INTO Applications (JobId, FreelancerId, CoverLetter, DateApplied) 
                    VALUES (@JobId, @FreelancerId, @CoverLetter, @DateApplied)";
                return await _dataDapper.ExecuteSqlAsync(sql, application);
            }


            public async Task<bool> UpdateApplicationAsync(int id, Application application)
            {
                var sql = @"UPDATE Applications SET 
                            JobId = @JobId, 
                            FreelancerId = @FreelancerId, 
                            CoverLetter = @CoverLetter, 
                            DateApplied = @DateApplied 
                            WHERE Id = @Id";
                application.Id = id;  
                return await _dataDapper.ExecuteSqlAsync(sql, application);
            }

            public async Task<bool> DeleteApplicationAsync(int id)
            {
                var sql = $"DELETE FROM Applications WHERE Id = {id}";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
            }
        }
    }
