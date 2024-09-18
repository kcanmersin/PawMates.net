using Core.Data.Entity.EntityBases;
using Core.Data.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity
{
    public class Post : EntityBase
    {
        public Guid UserId { get; set; } 
        public AppUser User { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<LikeDislike> LikesDislikes { get; set; } = new List<LikeDislike>();
        public virtual ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();

    }
}
