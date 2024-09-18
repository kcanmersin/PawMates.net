using MediatR;
using PawMates.Core.Features.Comments.DeleteComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.DeleteComment
{
    public class DeleteCommentCommand : IRequest<DeleteCommentResponse>
    {
        public Guid CommentId { get; set; } 
    }
}
