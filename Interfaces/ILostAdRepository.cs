using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PawMates.net.Dtos.Ad;

namespace PawMates.net.Interfaces
{
    public interface ILostAdRepository
    {
        Task<List<LostAdResponse>> GetAllAsync();
        Task<LostAdResponse?> GetByIdAsync(int id);
        Task<LostAdResponse> CreateAsync(CreateLostAdRequest lostAdDto);
        Task<LostAdResponse?> UpdateAsync(int id, UpdateLostAdRequest lostAdDto);
        Task<LostAdResponse?> DeleteAsync(int id);
    }
}
