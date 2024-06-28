using System;
using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Ad
{
    public class CreateAdRequest
    {
        [Required]
        public int PetId { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Location { get; set; }
    }
}
