using Core.Data.Entity.EntityBases;
using Core.Data.Entity.User;
using PawMates.Core.Data.Entity.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity
{
    public class LikeDislike : EntityBase
    {
        public Guid UserId { get; set; }  
        public AppUser User { get; set; }

        public Guid? PostId { get; set; } 
        public Post Post { get; set; }

        public Guid? AdvertisementId { get; set; } 
        public AdvertisementBase Advertisement { get; set; }

        public Guid? CommentId { get; set; }  
        public Comment Comment { get; set; }

        public bool IsLike { get; set; }
    }
}
