using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<UpdateCommentCommand> _validator;
        private readonly IFileUploadService _fileUploadService;  // File upload service for handling media

        public UpdateCommentHandler(ApplicationDbContext context, IValidator<UpdateCommentCommand> validator, IFileUploadService fileUploadService)
        {
            _context = context;
            _validator = validator;
            _fileUploadService = fileUploadService;
        }

        public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new UpdateCommentResponse
                {
                    Success = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            // Find the comment by ID
            var comment = await _context.Comments.Include(c => c.Media).FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);
            if (comment == null)
            {
                return new UpdateCommentResponse
                {
                    Success = false,
                    Message = "Comment not found."
                };
            }

            // Update comment content
            comment.Content = request.Content;

            // Handle media upload for the comment
            if (request.CommentMedia != null && request.CommentMedia.Count > 0)
            {
                // Remove old media files if needed
                var existingMedia = _context.CommentMedias.Where(cm => cm.CommentId == comment.Id);
                if (existingMedia.Any())
                {
                    _context.CommentMedias.RemoveRange(existingMedia);
                }

                // Add new media files
                foreach (var media in request.CommentMedia)
                {
                    var filePath = await _fileUploadService.UploadFileAsync(media, "comments");

                    var commentMedia = new CommentMedia
                    {
                        CommentId = comment.Id,
                        FilePath = filePath,
                        MediaType = media.ContentType.Contains("image") ? MediaType.Image : MediaType.Video
                    };

                    _context.CommentMedias.Add(commentMedia);
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCommentResponse
            {
                Success = true,
                Message = "Comment updated successfully."
            };
        }
    }
}
