using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PawMates.net.Models
{
    public class AppUser : IdentityUser
    {
           public virtual ICollection<Ad> Ads { get; set; } = new HashSet<Ad>();

    }
}
