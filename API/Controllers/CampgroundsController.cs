﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
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
        public async Task<ActionResult<IEnumerable<Campground>>> GetCampgrounds()
        {
            var results = await _campgroundRepository.GetAllCampgroundsAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campground>> GetCampgroundById(int id)
        {
            var results = await _campgroundRepository.GetCampgroundAsync(id);
            return Ok(results);
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

