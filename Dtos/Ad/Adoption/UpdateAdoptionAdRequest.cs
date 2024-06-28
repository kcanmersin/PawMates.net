using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Ad.Adoption
{
   public class UpdateAdoptionAdRequest : UpdateAdRequest
{
    public string Conditions { get; set; }  // Requirements for adoption
}

}