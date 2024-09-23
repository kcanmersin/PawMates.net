using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, UpdatePostResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploadService _fileUploadService; // Assuming you have a file upload service

        public UpdatePostHandler(ApplicationDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
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

            // Handle image uploads
            if (request.PostMedias != null && request.PostMedias.Count > 0)
            {
                // Optionally, remove old images if needed
                var existingMedia = _context.PostMedias.Where(pm => pm.PostId == post.Id);
                _context.PostMedias.RemoveRange(existingMedia); // Remove old media

                // Add new images
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
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdatePostResponse
            {
                Success = true,
                Message = "Post updated successfully with images."
            };
        }
    }
}
