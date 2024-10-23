using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CampgroundsController : BaseApiController
    {
        private readonly ICampgroundRepository _campgroundRepository;
        private readonly IMapper _mapper;

        public CampgroundsController(ICampgroundRepository campgroundRepository, IMapper mapper)
        {
            _campgroundRepository = campgroundRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampgroundDto>>> GetCampgrounds()
        {
            var results = await _campgroundRepository.GetCampsAsync();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampgroundDto>> GetCampgroundById(int id)
        {
            return await _campgroundRepository.GetCampAsync(id);
        }

        [HttpPost("new")]
        public async Task<ActionResult<Campground>> AddCampground(CampgroundDto campgroundDto)
        {
            var results = await _campgroundRepository.AddCampgroundAsync(campgroundDto);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCampground(int id, CampgroundDto campgroundDto)
        {
            var campground = await _campgroundRepository.GetCampgroundAsync(id);

            if (campground == null) return BadRequest("Campground doesn't exist");

            campground.Title = campgroundDto.Title;
            campground.Location = campgroundDto.Location;

            try
            {
                await _campgroundRepository.UpdateCampgroundAsync(campground);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

             return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteCampground(int id)
        {
            _campgroundRepository.DeleteCampgroundAsync(id);
        }
    }
}

