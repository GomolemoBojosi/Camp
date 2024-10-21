using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CampgroundRepository : ICampgroundRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CampgroundRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<Campground>> AddCampgroundAsync(CampgroundDto campgroundDto)
        {
            if (await CampgroundExists(campgroundDto.Title))
            {
                throw new Exception("Campground already exists");
            }

            var campground = new Campground()
            {
                Title = campgroundDto.Title,
                Location = campgroundDto.Location,
                Price = campgroundDto.Price,
                Description = campgroundDto.Description,
            };

            _context.Campgrounds.Add(campground);
            await _context.SaveChangesAsync();

            return campground;
        }

        public async Task DeleteCampgroundAsync(int id)
        {
            var campground = await GetCampgroundAsync(id);

            if (campground == null) throw new("Cannot delete, Campground doesn't exist");

            _context.Campgrounds.Remove(campground);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campground>> GetAllCampgroundsAsync()
        {
            return await _context.Campgrounds
                .Include(r => r.Reviews)
                .ToListAsync();
        }

        public async Task<Campground> GetCampgroundAsync(int id)
        {
            return await _context.Campgrounds
                .Include(r => r.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CampgroundDto> GetCampgroundDtoAsync(int id)
        {
            return await _context.Campgrounds
                .Where(x => x.Id == id)
                .ProjectTo<CampgroundDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CampgroundDto>> GetCampgroundsDtoAsync()
        {
            return await _context.Campgrounds
                .ProjectTo<CampgroundDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateCampgroundAsync(Campground campground)
        {
            _context.Campgrounds.Update(campground);
            await _context.SaveChangesAsync();
        }
        
        private async Task<bool> CampgroundExists(string title)
        {
            return await _context.Campgrounds.AnyAsync(c => c.Title == title.ToLower());
        }
    }
}
