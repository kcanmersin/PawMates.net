using FluentValidation;

namespace PawMates.Core.Features.LikesDislikes.CreateLikeDislike
{
    public class CreateLikeDislikeValidator : AbstractValidator<CreateLikeDislikeCommand>
    {
        public CreateLikeDislikeValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(x => x.IsLike)
                .NotNull()
                .WithMessage("IsLike must be specified.");

            RuleFor(x => x)
                .Must(x => (x.PostId.HasValue && !x.CommentId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.CommentId.HasValue && !x.PostId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.AdvertisementId.HasValue && !x.PostId.HasValue && !x.CommentId.HasValue))
                .WithMessage("You must provide either PostId, CommentId, or AdvertisementId, but not more than one.");
        }
    }
}
