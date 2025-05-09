using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataDapper _dataDapper;

        public ReviewService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            try
            {
                var sql = "SELECT * FROM Reviews";
                return await _dataDapper.LoadDataAsync<Review>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving reviews: {ex.Message}", ex);
            }
        }

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Reviews WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Review>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving review with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreateReviewAsync(Review review)
        {
            try
            {
                if (review == null)
                {
                    throw new ArgumentException("Review data is required.");
                }

                if (!review.IsValid(out string validationMessage))
                {
                    throw new ArgumentException($"Invalid review data: {validationMessage}");
                }

                var sql = @"INSERT INTO Reviews (Reviewer_Id, Reviewed_User_Id, Rating, Comment, Created_At) 
                            VALUES (@ReviewerId, @ReviewedUserId, @Rating, @Comment, @CreatedAt)";

                return await _dataDapper.ExecuteSqlAsync(sql, review);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating review: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Reviews WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting review with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
