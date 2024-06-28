using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PawMates.net.Dtos.Ad.Adoption;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/adoptionad")]
    [ApiController]
    public class AdoptionAdController : ControllerBase
    {
        private readonly IAdoptionAdRepository _adoptionAdRepo;
        private readonly IMapper _mapper;
        
        public AdoptionAdController(IAdoptionAdRepository adoptionAdRepo, IMapper mapper)
        {
            _adoptionAdRepo = adoptionAdRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adoptionAds = await _adoptionAdRepo.GetAllAsync();
            var adoptionAdDtos = _mapper.Map<List<AdoptionAdResponse>>(adoptionAds);
            return Ok(adoptionAdDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adoptionAd = await _adoptionAdRepo.GetByIdAsync(id);
            if (adoptionAd == null) return NotFound();
            var adoptionAdDto = _mapper.Map<AdoptionAdResponse>(adoptionAd);
            return Ok(adoptionAdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdoptionAdRequest adoptionAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var adoptionAd = await _adoptionAdRepo.CreateAsync(adoptionAdDto);
            var createdAdoptionAdDto = _mapper.Map<AdoptionAdResponse>(adoptionAd);
            return CreatedAtAction(nameof(GetById), new { id = adoptionAd.AdId }, createdAdoptionAdDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAdoptionAdRequest adoptionAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedAdoptionAd = await _adoptionAdRepo.UpdateAsync(id, adoptionAdDto);
            if (updatedAdoptionAd == null) return NotFound();
            var updatedAdoptionAdDto = _mapper.Map<AdoptionAdResponse>(updatedAdoptionAd);
            return Ok(updatedAdoptionAdDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var adoptionAd = await _adoptionAdRepo.DeleteAsync(id);
            if (adoptionAd == null) return NotFound();
            return NoContent();
        }
    }
}
