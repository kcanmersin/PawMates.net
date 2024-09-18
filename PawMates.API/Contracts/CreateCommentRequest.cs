using System.ComponentModel;

namespace PawMates.API.Contracts
{
    public class CreateCommentRequest
    {
        public Guid? PostId { get; set; } 
        public Guid? AdvertisementId { get; set; }
        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid UserId { get; set; }  
        public string Content { get; set; } = string.Empty;  
        public Guid? ParentCommentId { get; set; } 
    }
}