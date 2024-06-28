using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawMates.net.Dtos.Ad;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Repository
{
    public class AdRepository : IAdRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AdResponse>> GetAllAsync()
        {
            var ads = await _context.Ads.ToListAsync();
            return _mapper.Map<List<AdResponse>>(ads);
        }

        public async Task<AdResponse?> GetByIdAsync(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null) return null;
            return _mapper.Map<AdResponse>(ad);
        }

        public async Task<AdResponse> CreateAsync(CreateAdRequest adDto)
        {
            var ad = _mapper.Map<Ad>(adDto);
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdResponse>(ad);
        }

        public async Task<AdResponse?> UpdateAsync(int id, UpdateAdRequest adDto)
        {
            var existingAd = await _context.Ads.FindAsync(id);
            if (existingAd == null) return null;

            _mapper.Map(adDto, existingAd);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdResponse>(existingAd);
        }

        public async Task<AdResponse?> DeleteAsync(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null) return null;

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdResponse>(ad);
        }
    }
}
