using FluentValidation;

namespace PawMates.Core.Features.Comments.UpdateComment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty()
                .WithMessage("CommentId is required.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content must not be empty.")
                .MinimumLength(5)
                .WithMessage("Comment content must be at least 5 characters long.");
        }
    }
}
