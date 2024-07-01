using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Dtos.Ad
{
    public class UpdateAdRequest
    {
        
        public string Title { get; set; }
        public string Location { get; set; }

        //pet detail
        public List<UpdatePetRequest> PetDetails { get; set; }
    }
}