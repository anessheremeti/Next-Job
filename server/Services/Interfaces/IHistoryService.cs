using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistoryAsync();
        Task<History?> GetHistoryByIdAsync(int id);
        Task<bool> CreateHistoryAsync(History history);
        Task<bool> DeleteHistoryAsync(int id);
    }
}
