using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PawMates.net.Dtos.Ad;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/lostad")]
    [ApiController]
    public class LostAdController : ControllerBase
    {
        private readonly ILostAdRepository _lostAdRepo;
        private readonly IMapper _mapper;
        
        public LostAdController(ILostAdRepository lostAdRepo, IMapper mapper)
        {
            _lostAdRepo = lostAdRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lostAds = await _lostAdRepo.GetAllAsync();
            var lostAdDtos = _mapper.Map<List<LostAdResponse>>(lostAds);
            return Ok(lostAdDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lostAd = await _lostAdRepo.GetByIdAsync(id);
            if (lostAd == null) return NotFound();
            var lostAdDto = _mapper.Map<LostAdResponse>(lostAd);
            return Ok(lostAdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLostAdRequest lostAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var lostAd = await _lostAdRepo.CreateAsync(lostAdDto);
            

            var createdLostAdDto = _mapper.Map<LostAdResponse>(lostAd);
            return CreatedAtAction(nameof(GetById), new { id = lostAd.AdId }, createdLostAdDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLostAdRequest lostAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedLostAd = await _lostAdRepo.UpdateAsync(id, lostAdDto);
            if (updatedLostAd == null) return NotFound();
            var updatedLostAdDto = _mapper.Map<LostAdResponse>(updatedLostAd);
            return Ok(updatedLostAdDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lostAd = await _lostAdRepo.DeleteAsync(id);
            if (lostAd == null) return NotFound();
            return NoContent();
        }
    }
}
