using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CampgroundsController : BaseApiController
    {
        private readonly DataContext _context;

        public CampgroundsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campground>>> GetCampgrounds()
        {
            return await _context.Campgrounds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campground>> GetCampgroundById(int id)
        {
            var results = await _context.Campgrounds.FindAsync(id);
            return results;
        }

        [HttpPost("new")]
        public async Task<ActionResult<Campground>> AddCampground(CampgroundDto campgroundDto)
        {
            if (await CampgroundExists(campgroundDto.Title)) return BadRequest("Campground alread exists");

            var campground = new Campground()
            {
                Title = campgroundDto.Title,
                Location = campgroundDto.Location,
            };

            _context.Campgrounds.Add(campground);
            await _context.SaveChangesAsync();

            return campground;

        }

        private async Task<bool> CampgroundExists(string title)
        {
            return await _context.Campgrounds.AnyAsync(c => c.Title == title.ToLower());
        }
    }
}

