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
    public class Comment : EntityBase
    {
        public Guid UserId { get; set; }  
        public AppUser User { get; set; }

        public Guid? PostId { get; set; }  
        public Post Post { get; set; }

        public Guid? AdvertisementId { get; set; } 
        public AdvertisementBase Advertisement { get; set; }

        public string Content { get; set; }

        public Guid? ParentCommentId { get; set; }  
        public Comment ParentComment { get; set; }

        public ICollection<Comment> Replies { get; set; } = new List<Comment>();  
        public ICollection<LikeDislike> LikesDislikes { get; set; } = new List<LikeDislike>();  

        public ICollection<CommentMedia> Media { get; set; } = new List<CommentMedia>();


    }
}
