using MediatR;

namespace PawMates.Core.Features.LikesDislikes.DeleteLikeDislike
{
    public class DeleteLikeDislikeCommand : IRequest<DeleteLikeDislikeResponse>
    {
        public Guid UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
    }
}
