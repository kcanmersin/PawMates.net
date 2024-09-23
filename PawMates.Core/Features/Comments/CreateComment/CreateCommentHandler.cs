using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PawMates.Core.Features.Comments.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<CreateCommentCommand> _validator;
        private readonly IFileUploadService _fileUploadService; // Assuming you have this service for file uploads

        public CreateCommentHandler(ApplicationDbContext context, IValidator<CreateCommentCommand> validator, IFileUploadService fileUploadService)
        {
            _context = context;
            _validator = validator;
            _fileUploadService = fileUploadService;
        }

        public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CreateCommentResponse
                {
                    Success = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            // Create the comment
            var comment = new Comment
            {
                UserId = request.UserId,
                AdvertisementId = request.AdvertisementId,
                PostId = request.PostId,
                Content = request.Content,
                ParentCommentId = request.ParentCommentId,
                CreatedDate = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken);  // Save the comment first to get its ID

            // Handle media upload for the comment
            if (request.CommentMedia != null && request.CommentMedia.Count > 0)
            {
                foreach (var media in request.CommentMedia)
                {
                    // Upload file and get the file path
                    var filePath = await _fileUploadService.UploadFileAsync(media, "comments");

                    var commentMedia = new CommentMedia
                    {
                        CommentId = comment.Id, // Link media to the created comment
                        FilePath = filePath,
                        MediaType = media.ContentType.Contains("image") ? MediaType.Image : MediaType.Video
                    };

                    _context.CommentMedias.Add(commentMedia);
                }

                await _context.SaveChangesAsync(cancellationToken); // Save the media data
            }

            return new CreateCommentResponse
            {
                Success = true,
                CommentId = comment.Id,
                Message = "Comment created successfully."
            };
        }
    }
}
