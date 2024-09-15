using MediatR;
using PawMates.Core.Data.Entity.Ads;
using Pawmates.Core.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawMates.Core.Features.DTOs;

namespace PawMates.Core.Features.Ads.GetAllAds
{
    public class GetAllAdsHandler : IRequestHandler<GetAllAdsQuery, PaginatedAdsResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAdsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedAdsResponse> Handle(GetAllAdsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Set<AdvertisementBase>().AsNoTracking().AsQueryable();

            if (request.AdType.HasValue)
            {
                query = query.Where(ad => ad.AdvertisementType == request.AdType.Value);
            }

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(ad => ad.Title.Contains(request.SearchTerm) || ad.Description.Contains(request.SearchTerm));
            }
            var totalCount = await query.CountAsync(cancellationToken);

            var ads = await query
                .OrderByDescending(ad => ad.CreatedDate) 
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(ad => new AdvertisementDto
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    AdvertisementType = ad.AdvertisementType,
                    CreatedDate = ad.CreatedDate,
                    Location = ad.Location
                })
                .ToListAsync(cancellationToken);

            return new PaginatedAdsResponse
            {
                Ads = ads,
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };
        }
    }
}
