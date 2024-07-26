using FluentValidation;

namespace PawMates.Application.Features.Pets.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommandRequest>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pet name is required.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Pet type is required.");
            RuleFor(x => x.Breed).NotEmpty().WithMessage("Pet breed is required.");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Pet age must be greater than zero.");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Pet color is required.");
        }
    }
}
