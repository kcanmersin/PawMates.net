using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Dtos.Ad
{
    public class UpdateLostAdRequest: UpdateAdRequest
    {
        
        public UpdatePetRequest PetDetails { get; set; }
        public string LastSeenLocation { get; set; }

        public DateTime DateLost { get; set; }

        public string MicrochipId { get; set; }
    }
}