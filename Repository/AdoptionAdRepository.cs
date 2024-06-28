using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawMates.net.Dtos.Ad.Adoption;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Repository
{
    public class AdoptionAdRepository : IAdoptionAdRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdoptionAdRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AdoptionAdResponse>> GetAllAsync()
        {
            var adoptionAds = await _context.AdoptionAds.ToListAsync();
            return _mapper.Map<List<AdoptionAdResponse>>(adoptionAds);
        }

        public async Task<AdoptionAdResponse?> GetByIdAsync(int id)
        {
            var adoptionAd = await _context.AdoptionAds.FindAsync(id);
            if (adoptionAd == null) return null;
            return _mapper.Map<AdoptionAdResponse>(adoptionAd);
        }

        public async Task<AdoptionAdResponse> CreateAsync(CreateAdoptionAdRequest adoptionAdDto)
        {
            var adoptionAd = _mapper.Map<AdoptionAd>(adoptionAdDto);
            _context.AdoptionAds.Add(adoptionAd);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdoptionAdResponse>(adoptionAd);
        }

        public async Task<AdoptionAdResponse?> UpdateAsync(int id, UpdateAdoptionAdRequest adoptionAdDto)
        {
            var existingAdoptionAd = await _context.AdoptionAds.FindAsync(id);
            if (existingAdoptionAd == null) return null;

            _mapper.Map(adoptionAdDto, existingAdoptionAd);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdoptionAdResponse>(existingAdoptionAd);
        }

        public async Task<AdoptionAdResponse?> DeleteAsync(int id)
        {
            var adoptionAd = await _context.AdoptionAds.FindAsync(id);
            if (adoptionAd == null) return null;

            _context.AdoptionAds.Remove(adoptionAd);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdoptionAdResponse>(adoptionAd);
        }
    }
}
