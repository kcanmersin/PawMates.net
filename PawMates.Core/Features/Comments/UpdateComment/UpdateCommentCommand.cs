using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace PawMates.Core.Features.Comments.UpdateComment
{
    public class UpdateCommentCommand : IRequest<UpdateCommentResponse>
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<IFormFile> CommentMedia { get; set; } = new List<IFormFile>();
    }
}
