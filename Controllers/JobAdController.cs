using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/jobad")]
    [ApiController]
    public class JobAdController : ControllerBase
    {
        private readonly IJobAdRepository _jobAdRepo;
        private readonly IMapper _mapper;
        
        public JobAdController(IJobAdRepository jobAdRepo, IMapper mapper)
        {
            _jobAdRepo = jobAdRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobAds = await _jobAdRepo.GetAllAsync();
            var jobAdDtos = _mapper.Map<List<JobAdResponse>>(jobAds);
            return Ok(jobAdDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobAd = await _jobAdRepo.GetByIdAsync(id);
            if (jobAd == null) return NotFound();
            var jobAdDto = _mapper.Map<JobAdResponse>(jobAd);
            return Ok(jobAdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobAdRequest jobAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var jobAd = await _jobAdRepo.CreateAsync(jobAdDto);
            var createdJobAdDto = _mapper.Map<JobAdResponse>(jobAd);
            return CreatedAtAction(nameof(GetById), new { id = jobAd.AdId }, createdJobAdDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobAdRequest jobAdDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedJobAd = await _jobAdRepo.UpdateAsync(id, jobAdDto);
            if (updatedJobAd == null) return NotFound();
            var updatedJobAdDto = _mapper.Map<JobAdResponse>(updatedJobAd);
            return Ok(updatedJobAdDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobAd = await _jobAdRepo.DeleteAsync(id);
            if (jobAd == null) return NotFound();
            return NoContent();
        }
    }
}
