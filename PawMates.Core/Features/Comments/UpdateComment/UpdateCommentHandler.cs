using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Features.Comments.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<UpdateCommentCommand> _validator;

        public UpdateCommentHandler(ApplicationDbContext context, IValidator<UpdateCommentCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new UpdateCommentResponse
                {
                    Success = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            var comment = await _context.Comments.FindAsync(request.CommentId);

            if (comment == null)
            {
                return new UpdateCommentResponse
                {
                    Success = false,
                    Message = "Comment not found."
                };
            }

            comment.Content = request.Content;
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCommentResponse
            {
                Success = true,
                Message = "Comment updated successfully."
            };
        }
    }
}