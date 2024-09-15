using MediatR;
using System.Collections.Generic;
using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Features.DTOs;
using System.ComponentModel;

namespace PawMates.Core.Features.Ads.CreateAdvertisement
{
    public class CreateAdvertisementCommand : IRequest<CreateAdvertisementResponse>
    {
        //userid
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
        //[DefaultValue(typeof(DateTime), "2024-01-01T00:00:00Z")]  
        public DateTime? LostDate { get; set; } = DateTime.UtcNow; 

    }
}
