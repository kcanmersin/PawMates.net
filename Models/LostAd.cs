using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{ 
    public class LostAd : Ad
    {
        public override string AdType => "LostPet";

        public string LastSeenLocation { get; set; }

        public DateTime DateLost { get; set; }

        public string MicrochipId { get; set; }
    }
}