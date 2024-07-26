using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Domain.Entities
{
    public class AdoptionAd : AdBase
    {
        public AdoptionAd()
        {
        }


        public AdoptionAd(string title, string description, List<Pet> pets, List<string> imageUrls, bool isNeutered) : base(title, description, pets)//, imageUrls)
        {
            IsNeutered = isNeutered;
        }
        public bool IsNeutered { get; set; }
    }
}
