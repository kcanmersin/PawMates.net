using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawMates.net.Models
{
    [Table("Advertisements")]
     public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AdvertisementType Type { get; set; } // Enum for Job, LostFound, Adoption
        public DateTime PostedDate { get; set; }
        public DateTime? ExpiryDate { get; set; } // Optional, mainly for job listings
        public int PetId { get; set; } // Foreign key relation to Pet
        public virtual Pet Pet { get; set; } // Navigation property to the Pet

        public enum AdvertisementType
        {
            Job,
            LostFound,
            Adoption
        }
    }
}