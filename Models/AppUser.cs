using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PawMates.net.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();
    }
}