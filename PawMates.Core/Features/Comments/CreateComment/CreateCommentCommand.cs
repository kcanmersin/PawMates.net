using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.CreateComment
{
    public class CreateCommentCommand : IRequest<CreateCommentResponse>
    {
        public Guid? PostId { get; set; } 
        public Guid? AdvertisementId { get; set; }  
        public Guid UserId { get; set; }  
        public string Content { get; set; } = string.Empty; 
        public Guid? ParentCommentId { get; set; } 
    }
}
