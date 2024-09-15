using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity.Ads
{
    public class JobAd : AdvertisementBase
    {
        public JobAd()
        {
            AdvertisementType = AdvertisementType.Job;
        }
        public string RequiredDays { get; set; } 
        public decimal Salary { get; set; }
    }

}
