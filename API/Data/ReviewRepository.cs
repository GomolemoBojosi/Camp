using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly ICampgroundRepository _campgroundRepository;

        public ReviewRepository(DataContext context, ICampgroundRepository campgroundRepository)
        {
            _context = context;
            _campgroundRepository = campgroundRepository;
        }

        public async Task<ActionResult<Review>> CreateReviewAsync(ReviewDto reviewDto)
        {
            var campground = await _campgroundRepository.GetCampgroundByIdAsync(reviewDto.CampgroundId);

            if(campground == null)
            {
                throw new Exception("Campground does not exist");
            }

            var review = new Review
            {
                Body = reviewDto.Body,
                Rating = reviewDto.Rating,
                CampgroundId = campground.Id,
                UserId = reviewDto.userId
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return review; 
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
