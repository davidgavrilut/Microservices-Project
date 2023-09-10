using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PlatformService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() {
            Console.WriteLine("--> Getting Platforms...");
            var platformItems = _repository.GetAllPlatforms();
            // map returned data to PlaformReadDto
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet]
        [Route("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id) {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null) {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto) {
            // Create a new Platform using PlatformCreateDto 
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            // Expose newly created Platform through PlatformReadDto
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            // Return 201 Created with a route (GetPlatformById, id and platformReadDto)
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }

    }
}
