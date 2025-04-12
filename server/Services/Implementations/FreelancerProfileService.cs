using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class FreelancerProfileService : IFreelancerProfileService
    {
        private readonly DataDapper _dataDapper;

        public FreelancerProfileService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<FreelancerProfile>> GetFreelancerProfilesAsync()
        {
            try
            {
                var sql = "SELECT * FROM FreelancerProfile";
                return await _dataDapper.LoadDataAsync<FreelancerProfile>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving freelancer profiles: {ex.Message}", ex);
            }
        }

        public async Task<FreelancerProfile?> GetFreelancerProfileByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM FreelancerProfile WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<FreelancerProfile>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving freelancer profile with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateFreelancerProfileAsync(FreelancerProfile profile)
        {
            try
            {
                if (profile == null)
                {
                    throw new ArgumentException("Profile data is required.");
                }

                var sql = @"INSERT INTO FreelancerProfile (UserId, Skills, HourlyRate, PortfolioLink, Location, LastDelivery, MemberSince) 
                            VALUES (@UserId, @Skills, @HourlyRate, @PortfolioLink, @Location, @LastDelivery, @MemberSince)";
                return await _dataDapper.ExecuteSqlAsync(sql, profile);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating freelancer profile: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateFreelancerProfileAsync(int id, FreelancerProfile profile)
        {
            try
            {
                if (profile == null || id != profile.Id)
                {
                    throw new ArgumentException("Invalid freelancer profile data.");
                }

                var sql = @"UPDATE FreelancerProfile 
                            SET UserId = @UserId, Skills = @Skills, HourlyRate = @HourlyRate, PortfolioLink = @PortfolioLink, 
                                Location = @Location, LastDelivery = @LastDelivery, MemberSince = @MemberSince 
                            WHERE Id = @Id";
                profile.Id = id;
                return await _dataDapper.ExecuteSqlAsync(sql, profile);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating freelancer profile with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteFreelancerProfileAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM FreelancerProfile WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting freelancer profile with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
