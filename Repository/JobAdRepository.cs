using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawMates.Data;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Repository
{
    public class JobAdRepository : IJobAdRepository
    {
 private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IImageStorageService _imageStorageService;

    public JobAdRepository(ApplicationDbContext context, IMapper mapper, IImageStorageService imageStorageService)
    {
        _context = context;
        _mapper = mapper;
        _imageStorageService = imageStorageService;
    }

        public async Task<List<JobAdResponse>> GetAllAsync()
        {
            var jobAds = await _context.JobAds.ToListAsync();
            return _mapper.Map<List<JobAdResponse>>(jobAds);
        }

        public async Task<JobAdResponse?> GetByIdAsync(int id)
        {
            var jobAd = await _context.JobAds.FindAsync(id);
            if (jobAd == null) return null;
            return _mapper.Map<JobAdResponse>(jobAd);
        }

public async Task<JobAdResponse> CreateAsync(CreateJobAdRequest dto)
{
       var userExists = _context.Users.Any(u => u.Id == dto.AppUserId);
    if (!userExists)
    {
        System.Console.WriteLine("XXXXXXXXXXXXXXXXXXXUser does not exist");
        // Handle the situation, possibly by creating the user or selecting a different user ID
    }else
    {
        System.Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXUser exist");
    }

    var jobAd = _mapper.Map<JobAd>(dto); // Map DTO to JobAd entity

    //log detail of pet

    //log all pets name
     userExists = _context.Users.Any(u => u.Id == dto.AppUserId);
    if (!userExists)
    {
        System.Console.WriteLine("User does not exist");
        // Handle the situation, possibly by creating the user or selecting a different user ID
    }else
    {
        System.Console.WriteLine("User exist");
    }

    

    if (dto.Images != null && dto.Images.Count > 0)
    {
        foreach (var file in dto.Images)
        {
            if (file.Length > 0)
            {
                var filePath = await _imageStorageService.SaveImageAsync(file); // Save each file
                jobAd.Images.Add(new Image { FilePath = filePath }); // Create Image entity and add to JobAd
            }
        }
    }

    _context.JobAds.Add(jobAd);
    await _context.SaveChangesAsync();

    // Map the newly created JobAd entity back to JobAdResponse to return
    return _mapper.Map<JobAdResponse>(jobAd);
}



        public async Task<JobAdResponse?> UpdateAsync(int id, UpdateJobAdRequest jobAdDto)
        {
            var existingJobAd = await _context.JobAds.FindAsync(id);
            if (existingJobAd == null) return null;

            _mapper.Map(jobAdDto, existingJobAd);
            await _context.SaveChangesAsync();

            return _mapper.Map<JobAdResponse>(existingJobAd);
        }

        public async Task<JobAdResponse?> DeleteAsync(int id)
        {
            var jobAd = await _context.JobAds.FindAsync(id);
            if (jobAd == null) return null;

            _context.JobAds.Remove(jobAd);
            await _context.SaveChangesAsync();
            return _mapper.Map<JobAdResponse>(jobAd);
        }
    }
}
