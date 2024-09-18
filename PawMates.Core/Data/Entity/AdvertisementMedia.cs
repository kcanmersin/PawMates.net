using PawMates.Core.Data.Entity.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity
{
    public class AdvertisementMedia
    {
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; } 
        public AdvertisementBase Advertisement { get; set; } 

        public string FilePath { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow; 
    }
}
