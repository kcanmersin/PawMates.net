using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Ad
{
    public class CreateLostAdRequest : CreateAdRequest
{
  
        public string LastSeenLocation { get; set; }

        public DateTime DateLost { get; set; }

        public string MicrochipId { get; set; }
}
}