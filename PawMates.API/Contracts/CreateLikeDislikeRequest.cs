using System.ComponentModel;

namespace PawMates.API.Contracts
{
    public class CreateLikeDislikeRequest
    {
        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid UserId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
        public bool IsLike { get; set; }
    }
}
