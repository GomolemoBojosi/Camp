using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface ICampgroundRepository
    {
        Task<ActionResult<Campground>> AddCampgroundAsync(CampgroundDto campgroundDto);
        Task<bool> DeleteCampgroundAsync(int id);
        Task<IEnumerable<CampgroundDto>> GetCampgroundsAsync();
        Task<CampgroundDto> GetCampgroundByIdAsync(int id);
        Task<Campground> UpdateCampgroundAsync(CampgroundUpdateDto campgroundUpdateDto);
    }
}
