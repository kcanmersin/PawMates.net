using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawMates.Data;
using PawMates.net.Dtos.Ad;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Repository
{
    public class LostAdRepository : ILostAdRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LostAdRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LostAdResponse>> GetAllAsync()
        {
            var lostAds = await _context.LostAds.ToListAsync();
            return _mapper.Map<List<LostAdResponse>>(lostAds);
        }

        public async Task<LostAdResponse?> GetByIdAsync(int id)
        {
            var lostAd = await _context.LostAds.FindAsync(id);
            if (lostAd == null) return null;
            return _mapper.Map<LostAdResponse>(lostAd);
        }

        public async Task<LostAdResponse> CreateAsync(CreateLostAdRequest lostAdDto)
        {
            var lostAd = _mapper.Map<LostAd>(lostAdDto);
            _context.LostAds.Add(lostAd);
            await _context.SaveChangesAsync();
            return _mapper.Map<LostAdResponse>(lostAd);
        }

        public async Task<LostAdResponse?> UpdateAsync(int id, UpdateLostAdRequest lostAdDto)
        {
            var existingLostAd = await _context.LostAds.FindAsync(id);
            if (existingLostAd == null) return null;

            _mapper.Map(lostAdDto, existingLostAd);
            await _context.SaveChangesAsync();

            return _mapper.Map<LostAdResponse>(existingLostAd);
        }

        public async Task<LostAdResponse?> DeleteAsync(int id)
        {
            var lostAd = await _context.LostAds.FindAsync(id);
            if (lostAd == null) return null;

            _context.LostAds.Remove(lostAd);
            await _context.SaveChangesAsync();
            return _mapper.Map<LostAdResponse>(lostAd);
        }
    }
}
