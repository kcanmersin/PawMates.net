namespace PawMates.API.Contracts
{
    public class DeleteLikeDislikeRequest
    {
        public Guid UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AdvertisementId { get; set; }
    }
}
