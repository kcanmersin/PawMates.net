using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.Models
{
    [Table("Pets")]
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Dog, Cat, Bird, etc.
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } // Male, Female
        public string Description { get; set; } // Additional details about the pet
        //public string PhotoUrl { get; set; } // URL to a photo of the pet
    }
}
