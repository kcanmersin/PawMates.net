using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Dtos.Ad
{
    public class UpdateLostAdRequest: UpdateAdRequest
    {
        
        public string LostLocation { get; set; }
        public DateTime LostDate { get; set; }
        public string LostDescription { get; set; }
    }
}