using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity.Ads
{
    public class AdoptionAd : AdvertisementBase
    {
        public AdoptionAd()
        {
            AdvertisementType = AdvertisementType.Adoption;
        }

        public bool  IsVaccinated { get; set; }
    }

}
