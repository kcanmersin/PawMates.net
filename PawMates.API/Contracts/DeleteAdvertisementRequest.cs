using System.ComponentModel;

namespace PawMates.API.Contracts
{
    public class DeleteAdvertisementRequest
    {

        public Guid AdvertisementId { get; set; }

        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid UserId { get; set; } 
    }
}
