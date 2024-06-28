using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Pet
{
    public class PetResponse
    {
         public int PetId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }
    }
}