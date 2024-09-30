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
            if (await CampgroundExists(campgroundDto.Title)) return BadRequest("Campground already exists");

            var campground = new Campground()
            {
                Title = campgroundDto.Title,
                Location = campgroundDto.Location,
            };

            _context.Campgrounds.Add(campground);
            await _context.SaveChangesAsync();

            return campground;

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCampground(int id, CampgroundDto campgroundDto)
        {
            var campground = await GetCampgroundById(id);

            if (campground == null) return BadRequest("Campground doesn't exist");

            campground.Value.Title = campgroundDto.Title;
            campground.Value.Location = campgroundDto.Location;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

             return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCampground(int id)
        {
            var campground =await _context.Campgrounds.FindAsync(id);

            if (campground == null) return BadRequest("Cannot delete, Campground doesn't exist");

            _context.Campgrounds.Remove(campground);

            await _context.SaveChangesAsync();

            return NoContent();

        }

        private async Task<bool> CampgroundExists(string title)
        {
            return await _context.Campgrounds.AnyAsync(c => c.Title == title.ToLower());
        }
    }
}

