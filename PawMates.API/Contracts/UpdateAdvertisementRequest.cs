using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PawMates.API.Contracts
{
    public class UpdateAdvertisementRequest
    {
        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid AdvertisementId { get; set; }

        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid UserId { get; set; }

        [DefaultValue("Updated Ad Title")]
        public string Title { get; set; } = "Updated Ad Title";

        [DefaultValue("This is the updated description for the ad.")]
        public string Description { get; set; } = "This is the updated description for the ad.";

        [DefaultValue("Updated Location")]
        public string Location { get; set; } = "Updated Location";

        public List<PetDto> Pets { get; set; } = new List<PetDto>
        {
            new PetDto
            {
                Name = "Updated Pet Name",
                PetTypeId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Breed = "Updated Breed",
                Age = 3,
                Gender = "Female",
                Description = "Updated Description",
            }
        };

        [DefaultValue(AdvertisementType.Adoption)]
        public AdvertisementType AdvertisementType { get; set; } = AdvertisementType.Adoption;

        [DefaultValue(false)]
        public bool? IsVaccinated { get; set; } = false;

        [DefaultValue("Mon, Tue, Thu")]
        public string RequiredDays { get; set; } = "Mon, Tue, Thu";

        [DefaultValue(500.00)]
        public decimal? Salary { get; set; } = 500.00M;

        [DefaultValue("Updated last seen location.")]
        public string LastSeenLocation { get; set; } = "Updated last seen location.";

        [DefaultValue(typeof(DateTime), "2024-01-01T00:00:00Z")]
        public DateTime? LostDate { get; set; } = DateTime.UtcNow;
    }
}
