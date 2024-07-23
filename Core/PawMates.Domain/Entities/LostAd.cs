using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Domain.Entities
{
    public class LostAd : AdBase
    {
        public LostAd()
        {
        }

        //use base class constructor

        public LostAd(string title, string description, List<Pet> pets, List<string> imageUrls) : base(title, description, pets)//, imageUrls)
        {
        }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
    }

}
