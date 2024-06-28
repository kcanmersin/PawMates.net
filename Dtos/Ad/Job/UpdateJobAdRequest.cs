using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Ad.Job
{
    public class UpdateJobAdRequest : UpdateAdRequest
    {
        // [MaxLength(100)]
        // public string JobType { get; set; }

        // [MaxLength(500)]
        // public string JobDescription { get; set; }

        [MaxLength(100)]
        public string Salary { get; set; } 

        [MaxLength(100)]
        public string JobTitle { get; set; }

        public int WorkingHour { get; set; }
        
        
        
           }
}
