using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.net.Dtos.Pet;

namespace PawMates.net.Dtos.Ad
{
    public class AdResponse
    {
         public int AdId { get; set; }
    public int PetId { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime DatePosted { get; set; }
    public PetResponse Pet { get; set; }
    
    }
}