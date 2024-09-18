using MediatR;
using Microsoft.EntityFrameworkCore;
using Pawmates.Core.Data;
using PawMates.Core.Data.Entity;
using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.GetAllComments
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsQuery, PaginatedCommentsResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCommentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedCommentsResponse> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Set<Comment>().AsNoTracking().AsQueryable();

            if (request.AdvertisementId.HasValue)
            {
                query = query.Where(c => c.AdvertisementId == request.AdvertisementId.Value);
            }
            else if (request.PostId.HasValue)
            {
                query = query.Where(c => c.PostId == request.PostId.Value);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var comments = await query
                .OrderByDescending(c => c.CreatedDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Content = c.Content,
                    CreatedDate = c.CreatedDate,
                    AdvertisementId = c.AdvertisementId,
                    PostId = c.PostId,
                    ParentCommentId = c.ParentCommentId
                })
                .ToListAsync(cancellationToken);

            return new PaginatedCommentsResponse
            {
                Comments = comments,
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };
        }
    }
}
