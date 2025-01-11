using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ReviewController : BaseApiController
    {
        private readonly ICampgroundRepository _campground;
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(
            ICampgroundRepository campground,
            IReviewRepository reviewRepository)
        {
            _campground = campground;
            _reviewRepository = reviewRepository;
        }

        [HttpPost("add-review")]
        public async Task<ActionResult<Review>> CreateReview(ReviewDto reviewDto)
        {
            var results = await _reviewRepository.CreateReviewAsync(reviewDto);
            return Ok(results);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var results = await _reviewRepository.GetReviewsAsync();
            return Ok(results);
        }
    }
}

