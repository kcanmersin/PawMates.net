using MediatR;
using PawMates.Core.Data.Entity.Ads;
using Pawmates.Core.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PawMates.Core.Data.Entity;
using System;

namespace PawMates.Core.Features.Ads.CreateAdvertisement
{
    public class CreateAdvertisementHandler : IRequestHandler<CreateAdvertisementCommand, CreateAdvertisementResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateAdvertisementHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateAdvertisementResponse> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            AdvertisementBase advertisement;

            Guid userId = request.UserId;

            switch (request.AdvertisementType)
            {
                case AdvertisementType.Adoption:
                    advertisement = new AdoptionAd
                    {
                        Title = request.Title,
                        Description = request.Description,
                        Location = request.Location,
                        IsVaccinated = request.IsVaccinated ?? false,
                        Pets = request.Pets.Select(p => new Pet
                        {
                            Name = p.Name,
                            PetTypeId = p.PetTypeId,
                            Breed = p.Breed,
                            Age = p.Age,
                            Gender = p.Gender,
                            Description = p.Description
                        }).ToList(),
                        UserId = userId
                    };
                    break;

                case AdvertisementType.Job:
                    advertisement = new JobAd
                    {
                        Title = request.Title,
                        Description = request.Description,
                        Location = request.Location,
                        RequiredDays = request.RequiredDays,
                        Salary = request.Salary ?? 0,
                        Pets = request.Pets.Select(p => new Pet
                        {
                            Name = p.Name,
                            PetTypeId = p.PetTypeId,
                            Breed = p.Breed,
                            Age = p.Age,
                            Gender = p.Gender,
                            Description = p.Description
                        }).ToList(),
                        UserId = userId
                    };
                    break;

                case AdvertisementType.Lost:
                    advertisement = new LostAd
                    {
                        Title = request.Title,
                        Description = request.Description,
                        LastSeenLocation = request.LastSeenLocation,
                        Location = request.Location,
                        LostDate = request.LostDate.HasValue
                                    ? DateTime.SpecifyKind(request.LostDate.Value, DateTimeKind.Utc)
                                    : DateTime.UtcNow,
                        Pets = request.Pets.Select(p => new Pet
                        {
                            Name = p.Name,
                            PetTypeId = p.PetTypeId,
                            Breed = p.Breed,
                            Age = p.Age,
                            Gender = p.Gender,
                            Description = p.Description
                        }).ToList(),
                        UserId = userId
                    };
                    break;

                default:
                    return new CreateAdvertisementResponse
                    {
                        Success = false,
                        Message = "Invalid advertisement type"
                    };
            }

            _context.Set<AdvertisementBase>().Add(advertisement);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateAdvertisementResponse
            {
                AdvertisementId = advertisement.Id,
                Success = true,
                Message = "Advertisement created successfully"
            };
        }
    }
}
