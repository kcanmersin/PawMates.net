using FluentValidation;

namespace PawMates.Core.Features.Comments.DeleteComment
{
    public class DeleteCommentValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty()
                .WithMessage("CommentId is required.");
        }
    }
}
