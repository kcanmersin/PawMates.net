using MediatR;
using PawMates.Core.Data.Entity;
using Pawmates.Core.Data;
using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PawMates.Core.Features.Posts.GetAllPosts
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery, PaginatedPostsResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllPostsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedPostsResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Set<Post>()
                .AsNoTracking()
                .Include(post => post.Media) 
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(post => post.Title.Contains(request.SearchTerm) || post.Content.Contains(request.SearchTerm));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var posts = await query
                .OrderByDescending(post => post.CreatedDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(post => new PostDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedDate = post.CreatedDate,
                    UserId = post.UserId,
                    MediaUrls = post.Media.Select(m => m.FilePath).ToList() 
                })
                .ToListAsync(cancellationToken);

            return new PaginatedPostsResponse
            {
                Posts = posts,
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };
        }
    }
}
