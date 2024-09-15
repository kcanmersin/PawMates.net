using MediatR;
using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;

namespace PawMates.Core.Features.Ads.UpdateAdvertisement
{
    public class UpdateAdvertisementCommand : IRequest<UpdateAdvertisementResponse>
    {
        public Guid AdvertisementId { get; set; }  
        public Guid UserId { get; set; }  
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<PetDto> Pets { get; set; }  
        public AdvertisementType AdvertisementType { get; set; }
        public bool? IsVaccinated { get; set; }  
        public string RequiredDays { get; set; } 
        public decimal? Salary { get; set; } 
        public string LastSeenLocation { get; set; } 
        public DateTime? LostDate { get; set; } = DateTime.UtcNow; 
    }
}
