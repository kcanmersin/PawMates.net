using MediatR;
using PawMates.Application.Features.Pets.Command.CreatePet;
using PawMates.Application.Interfaces.UnitOfWorks;
using PawMates.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PawMates.Application.Features.Pets.Commands.CreatePet
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommandRequest, CreatePetCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreatePetCommandResponse> Handle(CreatePetCommandRequest request, CancellationToken cancellationToken)
        {
            var pet = new Pet
            {
                Name = request.Name,
                Type = request.Type,
                Breed = request.Breed,
                Age = request.Age,
                Color = request.Color
            };

            await _unitOfWork.GetWriteRepository<Pet>().AddAsync(pet);
            await _unitOfWork.SaveAsync();

            
            //return but id is Guid
            return new CreatePetCommandResponse
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Color = pet.Color
            };
        }
    }
}
