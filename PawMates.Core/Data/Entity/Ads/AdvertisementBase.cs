using Core.Data.Entity.EntityBases;
using Core.Data.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity.Ads
{
    public abstract class AdvertisementBase : EntityBase
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public string Title { get; set; } 
        public string Description { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
        public AdvertisementType AdvertisementType { get; set; }

        //   public virtual ICollection<AdvertisementImage> AdvertisementImages { get; set; } = new List<AdvertisementImage>();
    }

}
