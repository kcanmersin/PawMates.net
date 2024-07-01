using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PawMates.net.Dtos;
using PawMates.net.Dtos.Ad;

namespace PawMates.net.Interfaces
{
    public interface IAdRepository
    {
        Task<List<AdResponse>> GetAllAsync();
        Task<AdResponse?> GetByIdAsync(int id);
        Task<AdResponse> CreateAsync(CreateAdRequest adDto);
        Task<AdResponse?> UpdateAsync(int id, UpdateAdRequest adDto);
        Task<AdResponse?> DeleteAsync(int id);
    }
}
