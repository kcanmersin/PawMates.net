using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawMates.net.Dtos.Pet;
using PawMates.net.Interfaces;
using PawMates.net.Models;

namespace PawMates.net.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepo;
        private readonly IMapper _mapper;
        
        public PetController(IPetRepository petRepo, IMapper mapper)
        {
            _petRepo = petRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petRepo.GetAllAsync();
            var petDtos = _mapper.Map<List<PetResponse>>(pets);
            return Ok(petDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petRepo.GetByIdAsync(id);
            if (pet == null) return NotFound();
            var petDto = _mapper.Map<PetResponse>(pet);
            return Ok(petDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetRequest petDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var pet = await _petRepo.CreateAsync(petDto);

            
         
            var createdPetDto = _mapper.Map<PetResponse>(pet);
            return CreatedAtAction(nameof(GetById), new { id = pet.PetId }, createdPetDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePetRequest petDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedPet = await _petRepo.UpdateAsync(id, petDto);
            if (updatedPet == null) return NotFound();
            var updatedPetDto = _mapper.Map<PetResponse>(updatedPet);
            return Ok(updatedPetDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _petRepo.DeleteAsync(id);
            if (pet == null) return NotFound();
            return NoContent();
        }
    }
}
