using Microsoft.AspNetCore.Http;
using PawMates.net.Dtos.Pet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos
{
    public class CreateAdRequest
    {
        // public DateTime DatePosted { get; set; }

        // [MaxLength(200)]
        // public string Title { get; set; }

        // [MaxLength(500)]
        // public string Description { get; set; }

        // [MaxLength(300)]
        // public string Location { get; set; }

       public string AppUserId { get; set; }

        // Assuming you want to handle image uploads directly in the DTO
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        // public List<CreatePetRequest> PetDetails { get; set; } = new List<CreatePetRequest>();
    
        public CreatePetRequest PetDetails { get; set; }
    }
}
