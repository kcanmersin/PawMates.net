using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace PawMates.net.Models
{
    public class JobAd : Ad
    {
        public override string AdType => "JobAd";

        public string JobTitle { get; set; }

        //working hour
        public int WorkingHour { get; set; }

        public string Salary { get; set; }




    }
}