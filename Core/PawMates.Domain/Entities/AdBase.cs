using PawMates.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Domain.Entities
{
    public abstract class AdBase : EntityBase
    {

        public AdBase()
        {
        }

        public AdBase(string title, string description, List<Pet> pets )//, List<string> imageUrls)
        {
            Title = title;
            Description = description;
            Pets = pets;
          //  ImageUrls = imageUrls;
        }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();


      //  public List<string> ImageUrls { get; set; } = new List<string>();
    }

}
