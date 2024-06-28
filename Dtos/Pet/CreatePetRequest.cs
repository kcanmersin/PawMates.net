using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Pet
{
    public class CreatePetRequest
    {
        [Required]
    public string Name { get; set; }

    [Required]
    public string Type { get; set; } // E.g., Dog, Cat

    public int Age { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
    }
}