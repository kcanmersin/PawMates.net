using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, DeletePostResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeletePostHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeletePostResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Set<Post>().FindAsync(request.PostId);

            if (post == null)
            {
                return new DeletePostResponse
                {
                    Success = false,
                    Message = "Post not found."
                };
            }

            // Remove the post from the database
            _context.Set<Post>().Remove(post);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeletePostResponse
            {
                Success = true,
                Message = "Post deleted successfully."
            };
        }
    }
}
