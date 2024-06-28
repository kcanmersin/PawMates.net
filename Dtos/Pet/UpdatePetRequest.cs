using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Pet
{
    public class UpdatePetRequest
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public string Type { get; set; } // E.g., Dog, Cat

        [Range(0, 30)]
        public int Age { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
