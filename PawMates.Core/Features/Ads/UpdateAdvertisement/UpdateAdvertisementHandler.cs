using MediatR;
using Microsoft.EntityFrameworkCore;
using PawMates.Core.Data.Entity.Ads;
using Pawmates.Core.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Features.Ads.UpdateAdvertisement
{
    public class UpdateAdvertisementHandler : IRequestHandler<UpdateAdvertisementCommand, UpdateAdvertisementResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAdvertisementHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateAdvertisementResponse> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var advertisement = await _context.Set<AdvertisementBase>()
                                                  .Include(a => a.Pets)
                                                  .FirstOrDefaultAsync(a => a.Id == request.AdvertisementId && a.UserId == request.UserId, cancellationToken);

                if (advertisement == null)
                {
                    return new UpdateAdvertisementResponse
                    {
                        Success = false,
                        Message = "Advertisement not found or you are not authorized to update it."
                    };
                }

                advertisement.Title = request.Title;
                advertisement.Description = request.Description;
                advertisement.Location = request.Location;

                switch (advertisement)
                {
                    case AdoptionAd adoptionAd:
                        adoptionAd.IsVaccinated = request.IsVaccinated ?? adoptionAd.IsVaccinated;
                        break;

                    case JobAd jobAd:
                        jobAd.RequiredDays = request.RequiredDays ?? jobAd.RequiredDays;
                        jobAd.Salary = request.Salary ?? jobAd.Salary;
                        break;

                    case LostAd lostAd:
                        lostAd.LastSeenLocation = request.LastSeenLocation ?? lostAd.LastSeenLocation;
                        lostAd.LostDate = request.LostDate ?? lostAd.LostDate;
                        break;
                }

                foreach (var petDto in request.Pets)
                {
                    var existingPet = advertisement.Pets.FirstOrDefault(p => p.PetTypeId == petDto.PetTypeId);
                    if (existingPet != null)
                    {
                        existingPet.Name = petDto.Name;
                        existingPet.Breed = petDto.Breed;
                        existingPet.Age = petDto.Age;
                        existingPet.Gender = petDto.Gender;
                        existingPet.Description = petDto.Description;
                    }
                    else
                    {
                        var newPet = new Pet
                        {
                            Name = petDto.Name,
                            PetTypeId = petDto.PetTypeId,
                            Breed = petDto.Breed,
                            Age = petDto.Age,
                            Gender = petDto.Gender,
                            Description = petDto.Description
                        };
                        advertisement.Pets.Add(newPet);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateAdvertisementResponse
                {
                    AdvertisementId = advertisement.Id,
                    Success = true,
                    Message = "Advertisement updated successfully"
                };
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"An error occurred while updating the advertisement: {ex.Message}, Inner exception: {innerMessage}");

                return new UpdateAdvertisementResponse
                {
                    Success = false,
                    Message = $"An error occurred while updating the advertisement: {ex.Message}. Inner exception: {innerMessage}"
                };
            }
        }
    }
}
