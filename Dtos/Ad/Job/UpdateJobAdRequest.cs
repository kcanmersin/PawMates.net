using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Ad.Job
{
   public class UpdateJobAdRequest : UpdateAdRequest
{
    public string JobDescription { get; set; }
    public bool IsFullTime { get; set; }
}

}