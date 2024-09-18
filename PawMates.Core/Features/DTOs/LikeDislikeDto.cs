namespace PawMates.Core.Features.LikesDislikes
{
    public class LikeDislikeDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsLike { get; set; }
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
    }
}
