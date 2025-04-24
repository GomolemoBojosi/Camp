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
        private readonly IPhotoService _photoService;

        public CampgroundRepository(DataContext context, IMapper mapper, IPhotoService photoService)
        {
            _context = context;
            _mapper = mapper;
            _photoService = photoService;
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
                Image = campgroundDto.Image,
                UserId = campgroundDto.UserId,
            };

            _context.Campgrounds.Add(campground);
            await _context.SaveChangesAsync();

            return campground;
        }

        public async Task<bool> DeleteCampgroundAsync(int id)
        {
            var campground = await _context.Campgrounds.FirstOrDefaultAsync(x => x.Id == id);

            if (campground == null)
            {
                throw new Exception("campground not found");
            }

            _context.Campgrounds.Remove(campground);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Campground> GetCampgroundAsync(int id)
        {
            var results = await _context.Campgrounds
                .Include(r => r.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);
            return results;
        }

        public async Task<IEnumerable<CampgroundDto>> GetCampgroundsAsync()
        {
            return await _context.Campgrounds
                .ProjectTo<CampgroundDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CampgroundDto> GetCampgroundByIdAsync(int id)
        {
            return await _context.Campgrounds
                        .Where(x => x.Id == id)
                        .ProjectTo<CampgroundDto>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync();
        }

        public async Task<Campground> UpdateCampgroundAsync(CampgroundUpdateDto campgroundUpdateDto)
        {
            var campground = await GetCampgroundAsync(campgroundUpdateDto.Id);

            if (campground == null)
            {
                throw new("campground not found");
            }

            _mapper.Map(campgroundUpdateDto, campground);

            await _context.SaveChangesAsync();

            return campground;
        }

        public async Task<ActionResult<PhotoDto>> AddPhotoAsync(IFormFile file, int campgroundId)
        {
            var campground = await GetCampgroundAsync(campgroundId);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
            {
                throw new Exception(result.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                CampgroundId = campgroundId,
            };

            campground.Photos.Add(photo);

            await _context.SaveChangesAsync();

            return _mapper.Map<PhotoDto>(photo);
        }


        private async Task<bool> CampgroundExists(string title)
        {
            return await _context.Campgrounds.AnyAsync(c => c.Title == title.ToLower());
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 1;
        }
    }
}
