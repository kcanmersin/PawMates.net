using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploadService _fileUploadService; // Assuming you have a file upload service

        public CreatePostHandler(ApplicationDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
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
            await _context.SaveChangesAsync(cancellationToken); // Save post to get Post ID

            // Handle image uploads
            if (request.PostMedias != null && request.PostMedias.Count > 0)
            {
                foreach (var image in request.PostMedias)
                {
                    var filePath = await _fileUploadService.UploadFileAsync(image, "posts");

                    var postMedia = new PostMedia
                    {
                        PostId = post.Id,
                        FilePath = filePath,
                        MediaType = image.ContentType.Contains("image") ? MediaType.Image : MediaType.Video
                    };

                    _context.PostMedias.Add(postMedia); // Assuming PostMedias is the media entity for posts
                }

                await _context.SaveChangesAsync(cancellationToken); // Save images
            }

            return new CreatePostResponse
            {
                PostId = post.Id,
                Success = true,
                Message = "Post created successfully with images."
            };
        }
    }
}
