using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.Core.Features.LikesDislikes.GetAllLikesDislikes
{
    public class GetAllLikesDislikesHandler : IRequestHandler<GetAllLikesDislikesQuery, PaginatedLikesDislikesResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllLikesDislikesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedLikesDislikesResponse> Handle(GetAllLikesDislikesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.LikesDislikes.AsNoTracking().AsQueryable();

            if (request.PostId.HasValue)
            {
                query = query.Where(ld => ld.PostId == request.PostId.Value);
            }
            else if (request.CommentId.HasValue)
            {
                query = query.Where(ld => ld.CommentId == request.CommentId.Value);
            }
            else if (request.AdvertisementId.HasValue)
            {
                query = query.Where(ld => ld.AdvertisementId == request.AdvertisementId.Value);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var likesDislikes = await query
                .OrderByDescending(ld => ld.CreatedDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(ld => new LikeDislikeDto
                {
                    Id = ld.Id,
                    UserId = ld.UserId,
                    IsLike = ld.IsLike,
                    PostId = ld.PostId,
                    CommentId = ld.CommentId,
                    AdvertisementId = ld.AdvertisementId
                })
                .ToListAsync(cancellationToken);

            return new PaginatedLikesDislikesResponse
            {
                LikesDislikes = likesDislikes,
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };
        }
    }
}
