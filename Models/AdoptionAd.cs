using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace PawMates.net.Models
{
       [Table("AdoptionAds")]
    public class AdoptionAd : Ad
    {
        public override string AdType => "Adoption";

        public bool IsVaccinated { get; set; }

        public decimal AdoptionFee { get; set; }

        
    }
}