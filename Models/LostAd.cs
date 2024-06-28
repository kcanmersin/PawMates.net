using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{ 
     [Table("LostAds")]
    public class LostAd : Ad
    {
        public override string AdType => "LostPet";

        public string LastSeenLocation { get; set; }

        public string MicrochipId { get; set; }
    }
}