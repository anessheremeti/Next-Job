using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

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
            Console.WriteLine("HYRI NË CreateFreelancerProfileAsync");

            try
            {
                if (profile == null)
                {
                    throw new ArgumentException("Profile data is required.");
                }

                profile.Validate();

                Console.WriteLine("Të dhënat e profilit:");
                Console.WriteLine($"UserId: {profile.UserId}");
                Console.WriteLine($"Skills: {profile.Skills}");
                Console.WriteLine($"HourlyRate: {profile.HourlyRate}");
                Console.WriteLine($"PortfolioLink: {profile.PortfolioLink}");
                Console.WriteLine($"Location: {profile.Location}");
                Console.WriteLine($"LastDelivery: {profile.LastDelivery}");
                Console.WriteLine($"MemberSince: {profile.MemberSince}");

                var sql = @"
                    INSERT INTO FreelancerProfile (
                        user_id, skills, hourly_rate, portfolio_link, location, last_delivery, member_since
                    ) VALUES (
                        @UserId, @Skills, @HourlyRate, @PortfolioLink, @Location, @LastDelivery, @MemberSince
                    );";

                var result = await _dataDapper.ExecuteSqlAsync(sql, profile);

                Console.WriteLine("INSERT executed, result: " + result);

                return result;
            }
            catch (ValidationException ve)
            {
                Console.WriteLine("Validation failed: " + ve.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Insert failed: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

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

        public Task<IEnumerable<FreelancerProfile>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FreelancerProfile?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FreelancerProfile> CreateAsync(FreelancerProfile profile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
