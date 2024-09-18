using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Features.Comments.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<CreateCommentCommand> _validator;

        public CreateCommentHandler(ApplicationDbContext context, IValidator<CreateCommentCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CreateCommentResponse
                {
                    Success = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }
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
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCommentResponse
            {
                Success = true,
                CommentId = comment.Id,
                Message = "Comment created successfully."
            };
        }
    }
}
