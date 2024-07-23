using PawMates.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Domain.Entities
{
    public class Pet : EntityBase
    {
        public Pet()
        {
        }

        public Pet(string name, string type, string breed, int age, string color)
        {
            Name = name;
            Type = type;
            Breed = breed;
            Age = age;
            Color = color;
        }

        public string Name { get; set; }
        public string Type { get; set; }  // e.g., Dog, Cat
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
