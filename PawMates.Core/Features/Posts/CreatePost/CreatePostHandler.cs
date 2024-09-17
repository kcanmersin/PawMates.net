using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreatePostHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content,
                CreatedDate = DateTime.UtcNow
            };

            _context.Set<Post>().Add(post);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatePostResponse
            {
                PostId = post.Id,
                Success = true,
                Message = "Post created successfully"
            };
        }
    }
}
