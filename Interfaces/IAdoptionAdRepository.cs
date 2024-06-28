using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PawMates.net.Dtos.Ad.Adoption;

namespace PawMates.net.Interfaces
{
    public interface IAdoptionAdRepository
    {
        Task<List<AdoptionAdResponse>> GetAllAsync();
        Task<AdoptionAdResponse?> GetByIdAsync(int id);
        Task<AdoptionAdResponse> CreateAsync(CreateAdoptionAdRequest adoptionAdDto);
        Task<AdoptionAdResponse?> UpdateAsync(int id, UpdateAdoptionAdRequest adoptionAdDto);
        Task<AdoptionAdResponse?> DeleteAsync(int id);
    }
}
