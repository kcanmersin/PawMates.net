using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using System.Threading.Tasks;

namespace PawMates.Core.Features.LikesDislikes.DeleteLikeDislike
{
    public class DeleteLikeDislikeHandler : IRequestHandler<DeleteLikeDislikeCommand, DeleteLikeDislikeResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteLikeDislikeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteLikeDislikeResponse> Handle(DeleteLikeDislikeCommand request, CancellationToken cancellationToken)
        {
            var existingLikeDislike = await _context.LikesDislikes
                .FirstOrDefaultAsync(ld => ld.UserId == request.UserId &&
                                           (ld.PostId == request.PostId ||
                                            ld.CommentId == request.CommentId ||
                                            ld.AdvertisementId == request.AdvertisementId), cancellationToken);

            if (existingLikeDislike == null)
            {
                return new DeleteLikeDislikeResponse
                {
                    Success = false,
                    Message = "No like/dislike found for the given entity and user."
                };
            }

            _context.LikesDislikes.Remove(existingLikeDislike);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteLikeDislikeResponse
            {
                Success = true,
                Message = "Like/Dislike removed successfully."
            };
        }
    }
}
