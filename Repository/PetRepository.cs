using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawMates.Data;
using PawMates.net.Dtos.Pet;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PetRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PetResponse>> GetAllAsync()
        {
            var pets = await _context.Pets.ToListAsync();
            return _mapper.Map<List<PetResponse>>(pets);
        }

        public async Task<PetResponse?> GetByIdAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            return _mapper.Map<PetResponse>(pet);
        }

        public async Task<PetResponse> CreateAsync(CreatePetRequest petDto)
        {
            System.Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            var pet = _mapper.Map<Pet>(petDto);
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return _mapper.Map<PetResponse>(pet);
        }

        public async Task<PetResponse?> UpdateAsync(int id, UpdatePetRequest petDto)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return null;
            }

            _mapper.Map(petDto, pet);
            await _context.SaveChangesAsync();
            return _mapper.Map<PetResponse>(pet);
        }

        public async Task<PetResponse?> DeleteAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return null;
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return _mapper.Map<PetResponse>(pet);
        }
    }
}
