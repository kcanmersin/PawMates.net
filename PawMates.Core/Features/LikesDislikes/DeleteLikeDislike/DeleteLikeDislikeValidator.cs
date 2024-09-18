using FluentValidation;

namespace PawMates.Core.Features.LikesDislikes.DeleteLikeDislike
{
    public class DeleteLikeDislikeValidator : AbstractValidator<DeleteLikeDislikeCommand>
    {
        public DeleteLikeDislikeValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(x => x)
                .Must(x => (x.PostId.HasValue && !x.CommentId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.CommentId.HasValue && !x.PostId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.AdvertisementId.HasValue && !x.PostId.HasValue && !x.CommentId.HasValue))
                .WithMessage("You must provide either PostId, CommentId, or AdvertisementId, but not more than one.");
        }
    }
}