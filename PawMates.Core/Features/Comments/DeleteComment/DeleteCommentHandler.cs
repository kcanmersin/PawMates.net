using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Features.Comments.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<DeleteCommentCommand> _validator;

        public DeleteCommentHandler(ApplicationDbContext context, IValidator<DeleteCommentCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new DeleteCommentResponse
                {
                    Success = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            var comment = await _context.Comments
                .Include(c => c.Replies)
                .FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);

            if (comment == null)
            {
                return new DeleteCommentResponse
                {
                    Success = false,
                    Message = "Comment not found."
                };
            }

            if (comment.Replies != null && comment.Replies.Any())
            {
                _context.Comments.RemoveRange(comment.Replies);
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteCommentResponse
            {
                Success = true,
                Message = "Comment deleted successfully."
            };
        }
    }
}
