using PawMates.Application.DTOs;

namespace PawMates.Application.Features.Ads.LostAds.Commands.UpdateLostAd
{
    public class UpdateLostAdCommandResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PetDto> Pets { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
    }
}
