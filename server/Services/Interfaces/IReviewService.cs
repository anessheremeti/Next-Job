using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task<bool> CreateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
