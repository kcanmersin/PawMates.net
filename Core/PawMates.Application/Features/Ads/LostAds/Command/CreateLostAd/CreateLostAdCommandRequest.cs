using MediatR;
using PawMates.Application.DTOs;
using PawMates.Application.Features.Ads.LostAds.Command.CreateLostAd;
using System.Collections.Generic;

namespace PawMates.Application.Features.Ads.LostAds.Command.CreateLostAd
{
    public class CreateLostAdCommandRequest : IRequest<CreateLostAdCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PetDto> Pets { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
    }
}
