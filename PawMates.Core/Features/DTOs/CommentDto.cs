using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? AdvertisementId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}
