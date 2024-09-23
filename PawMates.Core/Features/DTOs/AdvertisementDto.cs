using PawMates.Core.Data.Entity.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.DTOs
{
    public class AdvertisementDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AdvertisementType AdvertisementType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }

        public List<string> MediaUrls { get; set; } = new List<string>();
    }
}
