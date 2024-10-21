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
        private readonly DataContext _context;
        private readonly ICampgroundRepository _campground;

        public ReviewController(DataContext context, ICampgroundRepository campground)
        {
            _context = context;
            _campground = campground;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                throw new Exception("Review cannot be null");
            }

            var campground = await _context.Campgrounds.FindAsync(reviewDto.CampgroundId);

            if(campground == null) { return NotFound("Campground not found"); }

            var review = new Review
            {
                Body = reviewDto.Body,
                CampgroundId = campground.Id,
                Rating = reviewDto.Rating,
            };

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return Ok(review);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var results = await _context.Reviews
                .Include(r => r.Campground)
                .ToListAsync();
            return Ok(results);
        }
    }
}

