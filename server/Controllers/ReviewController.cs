using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public ReviewController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/review
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var sql = "SELECT * FROM Review";

                var reviews = await Task.Run(() => _dataDapper.LoadData<Review>(sql));

                if (reviews == null || !reviews.Any())
                {
                    return NotFound("No reviews found.");
                }

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM Review WHERE Id = {id}";

                var review = await Task.Run(() => _dataDapper.LoadDataSingle<Review>(sql));

                if (review == null)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/review
        [HttpPost]
        public IActionResult CreateReview([FromBody] Review review)
        {
            try
            {
                if (review == null)
                {
                    return BadRequest("Review data is required.");
                }

                // Validate review data
                string validationMessage;
                if (!review.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO Review (ReviewerId, ReviewedUserId, Rating, Comment, CreatedAt) " +
                          $"VALUES ({review.ReviewerId}, {review.ReviewedUserId}, {review.Rating}, '{review.Comment}', '{review.CreatedAt}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create review.");
                }

                return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/review/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                var sql = $"DELETE FROM Review WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
