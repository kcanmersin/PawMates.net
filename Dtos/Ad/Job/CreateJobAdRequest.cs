using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Ad.Job
{
    public class CreateJobAdRequest : CreateAdRequest
    {
        // [Required]
        // public string JobType { get; set; }

        // [Required]
        // [MaxLength(500)]
        // public string JobDescription { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }
        
        [Required]
        //working hour
        public int WorkingHour { get; set; }


        [MaxLength(100)]
        public string Salary { get; set; }
    }
}
