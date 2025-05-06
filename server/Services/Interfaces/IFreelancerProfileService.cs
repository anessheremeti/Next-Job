using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFreelancerProfileService
{
    Task<IEnumerable<FreelancerProfile>> GetFreelancerProfilesAsync();
    Task<FreelancerProfile?> GetFreelancerProfileByIdAsync(int id);
    Task<bool> CreateFreelancerProfileAsync(FreelancerProfile profile);
    Task<bool> UpdateFreelancerProfileAsync(int id, FreelancerProfile profile);
    Task<bool> DeleteFreelancerProfileAsync(int id);
}
