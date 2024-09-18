using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.UpdateComment
{
    public class UpdateCommentCommand : IRequest<UpdateCommentResponse>
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
