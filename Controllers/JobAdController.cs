using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Interfaces;
using api.Extensions;
using Microsoft.AspNetCore.Identity;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/jobad")]
    [ApiController]
   // [Authorize]
    public class JobAdController : ControllerBase
    {
    string AdminId = "33d9b6a5-0694-4746-9314-e7066afe7e1b";
        private readonly IJobAdRepository _jobAdRepo;
        private readonly IMapper _mapper;

        //user manager
        private readonly UserManager<AppUser> _userManager;
public JobAdController(IJobAdRepository jobAdRepo, IMapper mapper, UserManager<AppUser> userManager)
{
    _jobAdRepo = jobAdRepo;
    _mapper = mapper;
    _userManager = userManager; // Correctly initialize _userManager
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
        [Consumes("multipart/form-data")] // This specifies that the endpoint expects form data
        public async Task<IActionResult> Create([FromBody] CreateJobAdRequest jobAdDto, [FromForm] List<IFormFile> imageFiles)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            //find user id
            // var username = User.GetUsername();
            // var appUser = await _userManager.FindByNameAsync(username);
            // if (appUser == null)
            //     return Unauthorized("User not found.");
            // jobAdDto.AppUserId = appUser.Id;

            jobAdDto.AppUserId = AdminId;


            

            var createdJobAd = await _jobAdRepo.CreateAsync(jobAdDto);
            if (createdJobAd == null)
                return StatusCode(500, "A problem occurred while handling your request.");

            //assing user
            
            return CreatedAtAction(nameof(GetById), new { id = createdJobAd.AdId }, createdJobAd);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobAdRequest jobAdDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedJobAd = await _jobAdRepo.UpdateAsync(id, jobAdDto);
            if (updatedJobAd == null)
                return NotFound("Job ad not found.");

            return Ok(updatedJobAd);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _jobAdRepo.DeleteAsync(id);
            if (result==null )
                return NotFound("Job ad not found or error deleting.");

            return NoContent();
        }
    }
}
