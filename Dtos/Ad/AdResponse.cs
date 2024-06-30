using System;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Dtos.Ad
{
    public class AdResponse
    {
        public int AdId { get; set; }
        public int PetId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime DatePosted { get; set; }
        public PetResponse PetDetails { get; set; }
    }
}
