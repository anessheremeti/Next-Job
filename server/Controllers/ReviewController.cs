using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/review
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewService.GetReviewsAsync();

            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found.");

            return Ok(reviews);
        }

        // GET api/review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);

            if (review == null)
                return NotFound($"Review with ID {id} not found.");

            return Ok(review);
        }

        // POST api/review
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (review == null)
                return BadRequest("Review data is required.");

            if (!review.IsValid(out string validationMessage))
                return BadRequest(validationMessage);

            var isCreated = await _reviewService.CreateReviewAsync(review);
            if (!isCreated)
                return StatusCode(500, "Failed to create review.");

            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }

        // DELETE api/review/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var isDeleted = await _reviewService.DeleteReviewAsync(id);

            if (!isDeleted)
                return NotFound($"Review with ID {id} not found.");

            return NoContent();
        }
    }
}
