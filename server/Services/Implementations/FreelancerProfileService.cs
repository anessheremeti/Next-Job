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
                return await _dataDapper.LoadDataSingleAsync<FreelancerProfile>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving freelancer profile with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateFreelancerProfileAsync(FreelancerProfile profile)
        {
<<<<<<< HEAD
=======
            Console.WriteLine("HYRI NË CreateFreelancerProfileAsync");

>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
            try
            {
                string validationMessage = string.Empty;
                if (profile == null || !profile.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid profile data: {validationMessage}");
                }

<<<<<<< HEAD
                var sql = @"INSERT INTO FreelancerProfile 
                            (user_id, skills, hourly_rate, portfolio_link, location, last_delivery, member_since) 
                            VALUES 
                            (@UserId, @Skills, @HourlyRate, @PortfolioLink, @Location, @LastDelivery, @MemberSince)";

                return await _dataDapper.ExecuteSqlAsync(sql, profile);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating freelancer profile: {ex.Message}", ex);
            }
        }
=======
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

        
        
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

        public async Task<bool> UpdateFreelancerProfileAsync(int id, FreelancerProfile profile)
        {
            try
            {
                string validationMessage = string.Empty;
                if (profile == null || id != profile.Id || !profile.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid profile data: {validationMessage}");
                }

                var sql = @"UPDATE FreelancerProfile 
                            SET user_id = @UserId, skills = @Skills, hourly_rate = @HourlyRate, 
                                portfolio_link = @PortfolioLink, location = @Location, 
                                last_delivery = @LastDelivery, member_since = @MemberSince 
                            WHERE id = @Id";

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
                var sql = "DELETE FROM FreelancerProfile WHERE id = @Id";
                return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
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
