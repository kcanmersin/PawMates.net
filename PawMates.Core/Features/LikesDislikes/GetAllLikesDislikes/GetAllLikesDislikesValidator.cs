using FluentValidation;

namespace PawMates.Core.Features.LikesDislikes.GetAllLikesDislikes
{
    public class GetAllLikesDislikesValidator : AbstractValidator<GetAllLikesDislikesQuery>
    {
        public GetAllLikesDislikesValidator()
        {
            RuleFor(x => x)
                .Must(x => (x.PostId.HasValue && !x.CommentId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.CommentId.HasValue && !x.PostId.HasValue && !x.AdvertisementId.HasValue) ||
                           (x.AdvertisementId.HasValue && !x.PostId.HasValue && !x.CommentId.HasValue))
                .WithMessage("You must provide either PostId, CommentId, or AdvertisementId, but not more than one.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size must be greater than 0.");
        }
    }
}
