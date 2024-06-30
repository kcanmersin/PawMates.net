using System;
using System.ComponentModel.DataAnnotations;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Dtos.Ad
{
    public class CreateAdRequest
    {
        [Required]
        public CreatePetRequest PetDetails { get; set; }
 

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Location { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }


        //USER ID
        public string AppUserId { get; set; }
    }
}
