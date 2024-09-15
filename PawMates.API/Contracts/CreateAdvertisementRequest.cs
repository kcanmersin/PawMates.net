using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PawMates.Core.Features.Ads.CreateAdvertisement
{
    public class CreateAdvertisementRequest
    {
        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid? UserId { get; set; }

        [DefaultValue("Ad Title")] 
        public string Title { get; set; } = "Default Title";

        [DefaultValue("This is the default description for the ad.")]
        public string Description { get; set; } = "This is the default description.";

        [DefaultValue("Default Location")]
        public string Location { get; set; } = "Default Location";

        [DefaultValue(AdvertisementType.Adoption)] 
        public AdvertisementType AdvertisementType { get; set; } = AdvertisementType.Adoption;

        public List<PetDto> Pets { get; set; } = new List<PetDto>
        {
            new PetDto
            {
                Name = "Default Pet Name",
                PetTypeId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 
                Breed = "Default Breed",
                Age = 2,
                Gender = "Male",
                Description = "Default Description",
            }
        };

        [DefaultValue(false)]
        public bool? IsVaccinated { get; set; } = false;

        [DefaultValue("Mon, Wed, Fri")]
        public string RequiredDays { get; set; } = "Mon, Wed, Fri";

        [DefaultValue(0)]
        public decimal? Salary { get; set; } = 0;

        [DefaultValue("Last seen at default location.")]
        public string LastSeenLocation { get; set; } = "Last seen at default location";

        [DefaultValue(typeof(DateTime), "2024-01-01T00:00:00Z")]  
        public DateTime? LostDate { get; set; } = DateTime.UtcNow;



    }
}
