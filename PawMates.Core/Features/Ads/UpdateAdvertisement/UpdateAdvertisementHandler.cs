using MediatR;
using Microsoft.EntityFrameworkCore;
using PawMates.Core.Data.Entity.Ads;
using Pawmates.Core.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using PawMates.Core.Data.Entity;
using System.Collections.Generic;

namespace PawMates.Core.Features.Ads.UpdateAdvertisement
{
    public class UpdateAdvertisementHandler : IRequestHandler<UpdateAdvertisementCommand, UpdateAdvertisementResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploadService _fileUploadService;

        public UpdateAdvertisementHandler(ApplicationDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
        }

        public async Task<UpdateAdvertisementResponse> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var advertisement = await _context.Set<AdvertisementBase>()
                                                  .Include(a => a.Pets)
                                                  .Include(a => a.Media) 
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

                if (request.AdvertisementImages != null && request.AdvertisementImages.Any())
                {
                    if (advertisement.Media.Any())
                    {
                        _context.AdvertisementMedias.RemoveRange(advertisement.Media);
                    }

                    foreach (var image in request.AdvertisementImages)
                    {
                        var filePath = await _fileUploadService.UploadFileAsync(image, "advertisements");

                        var media = new AdvertisementMedia
                        {
                            AdvertisementId = advertisement.Id,
                            FilePath = filePath,
                            MediaType = MediaType.Image
                        };

                        _context.AdvertisementMedias.Add(media);
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
