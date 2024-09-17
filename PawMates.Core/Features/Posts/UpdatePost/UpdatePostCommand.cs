using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostResponse>
    {
        public Guid PostId { get; set; }
        public string Title { get; set; } = string.Empty;  
        public string Content { get; set; } = string.Empty;  
    }
}
