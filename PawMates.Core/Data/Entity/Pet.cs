using Core.Data.Entity.EntityBases;
using PawMates.Core.Data.Entity.Ads;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace PawMates.Core.Data.Entity
{
    public class Pet : EntityBase
    {
        public string Name { get; set; }
        public Guid PetTypeId { get; set; } 
        public PetType PetType { get; set; } 
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } 
        public string Description { get; set; } 
        public Guid AdvertisementId { get; set; } 
        public AdvertisementBase Advertisement { get; set; } 

        //public virtual ICollection<PetImage> PetImages { get; set; } = new List<PetImage>(); 
    }
}
