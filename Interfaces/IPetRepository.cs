using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Interfaces
{
    public interface IPetRepository
    {
        Task<List<PetResponse>> GetAllAsync();
        Task<PetResponse?> GetByIdAsync(int id);
        Task<PetResponse> CreateAsync(CreatePetRequest petDto);
        Task<PetResponse?> UpdateAsync(int id, UpdatePetRequest petDto);
        Task<PetResponse?> DeleteAsync(int id);
    }
}
