using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var results = await _context.Cities.ToListAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GeCityById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }
    }
}
