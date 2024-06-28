using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{
    [Table("Ads")]
    public abstract class Ad
    {
        [Key]
        public int AdId { get; set; }

        public int PetId { get; set; }

        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        public DateTime DatePosted { get; set; }

        [Required]
        public string Title { get; set; }

        public string Location { get; set; }

        public virtual string AdType { get; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
