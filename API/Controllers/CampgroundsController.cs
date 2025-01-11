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

        public CampgroundsController(ICampgroundRepository campgroundRepository)
        {
            _campgroundRepository = campgroundRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampgroundDto>>> GetCampgrounds()
        {
            var results = await _campgroundRepository.GetCampgroundsAsync();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampgroundDto>> GetCampgroundById(int id)
        {
            return await _campgroundRepository.GetCampgroundByIdAsync(id);
        }

        [HttpPost("new")]
        public async Task<ActionResult<Campground>> AddCampground(CampgroundDto campgroundDto)
        {
            var results = await _campgroundRepository.AddCampgroundAsync(campgroundDto);
            return Ok(results.Value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCampground(CampgroundUpdateDto campgroundUpdateDto)
        {
            var campground = await _campgroundRepository.UpdateCampgroundAsync(campgroundUpdateDto);

            return Ok(campground);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Campground>> DeleteCampground(int id)
        {
            var campgroundToDelete = await _campgroundRepository.GetCampgroundByIdAsync(id);

            if(campgroundToDelete == null) {
                return NotFound("");
            }

            return await _campgroundRepository.DeleteCampgroundAsync(id);
        }
    }
}

