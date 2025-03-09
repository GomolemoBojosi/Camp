using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<ActionResult<Review>> CreateReviewAsync(ReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(int id);
    }
}
