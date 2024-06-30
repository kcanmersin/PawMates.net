using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<JobAdResponse> CreateAsync(CreateJobAdRequest jobAdDto)
    {
        var jobAd = _mapper.Map<JobAd>(jobAdDto);

        if (jobAdDto.PetDetails != null && jobAdDto.PetDetails.ImageFiles != null)
        {
            var pet = _mapper.Map<Pet>(jobAdDto.PetDetails);
            foreach (var file in jobAdDto.PetDetails.ImageFiles)
            {
                var imageUrl = await _imageStorageService.SaveImageAsync(file);
                pet.ImageUrls.Add(imageUrl);
            }
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            jobAd.Pets.Add(pet);
        }

        _context.JobAds.Add(jobAd);
        await _context.SaveChangesAsync();
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
