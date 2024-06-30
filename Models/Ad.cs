using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{
    public abstract class Ad
    {
        [Key]
        public int AdId { get; set; }

        public DateTime DatePosted { get; set; }

        // [Required]
        public string Title { get; set; }

        // [Required]
        public string Description { get; set; }

        public string Location { get; set; }

        public virtual string AdType { get; }


    [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
