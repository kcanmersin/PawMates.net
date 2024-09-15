using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity.Ads
{
    public class LostAd : AdvertisementBase
    {
        public LostAd()
        {
            AdvertisementType = AdvertisementType.Lost;
        }
        public string LastSeenLocation { get; set; }
        private DateTime _lostDate = DateTime.UtcNow;
        public DateTime LostDate
        {
            get => _lostDate;
            set => _lostDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
