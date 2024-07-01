using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Interfaces;
using Microsoft.AspNetCore.Identity;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/jobad")]
    [ApiController]
    // [Authorize]
    public class JobAdController : ControllerBase
    {
        string AdminId = "bc4ed45f-b25e-4e00-9a5d-0a52409dc97c";
        private readonly IJobAdRepository _jobAdRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        private readonly IImageStorageService _imageStorageService;
        public JobAdController(IJobAdRepository jobAdRepo, IMapper mapper, UserManager<AppUser> userManager, IImageStorageService imageStorageService)
        {
            _jobAdRepo = jobAdRepo;
            _mapper = mapper;
            _userManager = userManager; // Correctly initialize _userManager
            _imageStorageService = imageStorageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobAds = await _jobAdRepo.GetAllAsync();
            return Ok(jobAds);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobAd = await _jobAdRepo.GetByIdAsync(id);
            if (jobAd == null)
                return NotFound();

            return Ok(jobAd);
        }
[HttpPost]
public async Task<IActionResult> Create([FromForm] CreateJobAdRequest jobAdDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    System.Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXX");
    System.Console.WriteLine(jobAdDto.PetDetails.Name);
    System.Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXX");

  

    jobAdDto.AppUserId = AdminId;


  

    var createdJobAd = await _jobAdRepo.CreateAsync(jobAdDto);
    if (createdJobAd == null)
    {
        return StatusCode(500, "Failed to create job ad");
    }

    // Assuming `GetById` is an existing method that can retrieve the job ad details
    return CreatedAtAction(nameof(GetById), new { id = createdJobAd.AdId }, createdJobAd);
}



        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobAdRequest jobAdDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedJobAd = await _jobAdRepo.UpdateAsync(id, jobAdDto);
            if (updatedJobAd == null)
            {
                return NotFound("Job ad not found.");
            }

            return Ok(updatedJobAd);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _jobAdRepo.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Job ad not found or error deleting.");
            }

            return NoContent();
        }
    }
}
