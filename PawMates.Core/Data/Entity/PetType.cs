using Core.Data.Entity.EntityBases;
using System.Collections.Generic;

namespace PawMates.Core.Data.Entity
{
    public class PetType : EntityBase
    {
        public string Species { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
