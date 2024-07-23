using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Domain.Entities
{
    public class JobAd : AdBase
    {
        public JobAd()
        {
        }

        //use base class constructor
        public JobAd(string title, string description, List<Pet> pets, List<string> imageUrls) : base(title, description, pets)//, imageUrls)
        {
        }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public bool IsFullTime { get; set; }
    }
}
