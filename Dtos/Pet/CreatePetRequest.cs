using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Pet
{
    public class CreatePetRequest
    {
       // [Required]
        [MaxLength(100)]
        public string Name { get; set; }

      //  // [Required]
      //   public string Type { get; set; } // E.g., Dog, Cat

      //   [Range(0, 30)]
      //   public int Age { get; set; }

      //   [MaxLength(500)]
      //   public string Description { get; set; }

        // public List<string> ImageUrls { get; set; } = new List<string>();
      //    public IFormFileCollection ImageFiles { get; set; }
    }
}
