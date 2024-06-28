using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace PawMates.net.Models
{
   [Table("JobAds")]
    public class JobAd : Ad
    {
        public override string AdType => "JobAd";




    }
}