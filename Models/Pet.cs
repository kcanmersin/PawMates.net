using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; } // Dog, Cat, etc.

        public int Age { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }


        public List<string> ImageUrls { get; set; } = new List<string>();

    }
}