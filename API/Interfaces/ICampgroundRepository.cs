using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface ICampgroundRepository
    {
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Campground>> GetAllCampgroundsAsync();
        Task<Campground> GetCampgroundAsync(int id);
        Task<ActionResult<Campground>> AddCampgroundAsync(CampgroundDto campgroundDto);
        Task UpdateCampgroundAsync(Campground campground);
        Task DeleteCampgroundAsync(int id);
        Task<IEnumerable<CampgroundDto>> GetCampgroundsDtoAsync();
        Task<CampgroundDto> GetCampgroundDtoAsync(int id);
    }
}
