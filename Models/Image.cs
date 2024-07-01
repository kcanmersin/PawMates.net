using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string FilePath { get; set; }

        [ForeignKey("Ad")]
        public int AdId { get; set; }
        public virtual Ad Ad { get; set; }
    }
}
