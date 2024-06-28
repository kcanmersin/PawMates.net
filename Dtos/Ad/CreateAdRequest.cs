using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Ad
{
    public class CreateAdRequest
    {
          public int PetId { get; set; }
    public DateTime DatePosted { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    }
}