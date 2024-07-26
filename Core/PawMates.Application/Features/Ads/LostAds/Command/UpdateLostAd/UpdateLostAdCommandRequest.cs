using MediatR;
using PawMates.Application.DTOs;
using System;
using System.Collections.Generic;

namespace PawMates.Application.Features.Ads.LostAds.Commands.UpdateLostAd
{
    public class UpdateLostAdCommandRequest : IRequest<UpdateLostAdCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PetDto> Pets { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
    }
}
