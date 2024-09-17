using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, UpdatePostResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePostHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdatePostResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Set<Post>().FindAsync(request.PostId);

            if (post == null)
            {
                return new UpdatePostResponse
                {
                    Success = false,
                    Message = "Post not found."
                };
            }

            // Update the post's properties
            post.Title = request.Title;
            post.Content = request.Content;

            // Save changes to the database
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdatePostResponse
            {
                Success = true,
                Message = "Post updated successfully."
            };
        }
    }
}
