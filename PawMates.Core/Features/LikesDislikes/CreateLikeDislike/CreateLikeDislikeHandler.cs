using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Features.LikesDislikes.CreateLikeDislike
{
    public class CreateLikeDislikeHandler : IRequestHandler<CreateLikeDislikeCommand, CreateLikeDislikeResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateLikeDislikeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateLikeDislikeResponse> Handle(CreateLikeDislikeCommand request, CancellationToken cancellationToken)
        {
            var existingLikeDislike = await _context.Set<LikeDislike>()
                .FirstOrDefaultAsync(ld => ld.UserId == request.UserId &&
                                           (ld.PostId == request.PostId ||
                                            ld.CommentId == request.CommentId ||
                                            ld.AdvertisementId == request.AdvertisementId), cancellationToken);

            if (existingLikeDislike != null)
            {
                existingLikeDislike.IsLike = request.IsLike;
                _context.LikesDislikes.Update(existingLikeDislike);
            }
            else
            {
                var likeDislike = new LikeDislike
                {
                    UserId = request.UserId,
                    PostId = request.PostId,
                    CommentId = request.CommentId,
                    AdvertisementId = request.AdvertisementId,
                    IsLike = request.IsLike,
                    CreatedDate = DateTime.UtcNow
                };

                _context.LikesDislikes.Add(likeDislike);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateLikeDislikeResponse
            {
                Success = true,
                Message = "Like/Dislike processed successfully."
            };
        }
    }
}
