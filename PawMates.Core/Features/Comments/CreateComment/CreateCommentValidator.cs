using FluentValidation;

namespace PawMates.Core.Features.Comments.CreateComment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x)
                .Must(x => (x.AdvertisementId.HasValue && !x.PostId.HasValue) || (!x.AdvertisementId.HasValue && x.PostId.HasValue))
                .WithMessage("Either AdvertisementId or PostId must be provided, but not both.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content must not be empty.")
                .MinimumLength(5)
                .WithMessage("Comment content must be at least 5 characters long.");
        }
    }
}
