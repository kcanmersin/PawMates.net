using MediatR;
using PawMates.Application.Features.Pets.Command.CreatePet;

namespace PawMates.Application.Features.Pets.Commands.CreatePet
{
    public class CreatePetCommandRequest : IRequest<CreatePetCommandResponse>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
