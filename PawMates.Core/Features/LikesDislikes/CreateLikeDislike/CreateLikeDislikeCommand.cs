using MediatR;

namespace PawMates.Core.Features.LikesDislikes.CreateLikeDislike
{
    public class CreateLikeDislikeCommand : IRequest<CreateLikeDislikeResponse>
    {
        public Guid UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
        public bool IsLike { get; set; }
    }
}
