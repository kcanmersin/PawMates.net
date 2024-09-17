using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.DeletePost
{
    public class DeletePostCommand : IRequest<DeletePostResponse>
    {
        public Guid PostId { get; set; }  
    }
}
