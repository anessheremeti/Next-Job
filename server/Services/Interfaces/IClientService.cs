using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientProfile>> GetClientProfilesAsync();
        Task<ClientProfile?> GetClientProfileByIdAsync(int id);
        Task<bool> CreateClientProfileAsync(ClientProfile clientProfile);
        Task<bool> UpdateClientProfileAsync(int id, ClientProfile clientProfile);
        Task<bool> DeleteClientProfileAsync(int id);
    }
}
