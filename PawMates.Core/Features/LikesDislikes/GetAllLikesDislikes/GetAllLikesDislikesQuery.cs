using MediatR;

namespace PawMates.Core.Features.LikesDislikes.GetAllLikesDislikes
{
    public class GetAllLikesDislikesQuery : IRequest<PaginatedLikesDislikesResponse>
    {
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
