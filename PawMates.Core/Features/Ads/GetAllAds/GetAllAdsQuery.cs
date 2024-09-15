using MediatR;
using PawMates.Core.Data.Entity.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Ads.GetAllAds
{
    public class GetAllAdsQuery : IRequest<PaginatedAdsResponse>
    {
        public int PageNumber { get; set; } = 1;  
        public int PageSize { get; set; } = 10;  
        public AdvertisementType? AdType { get; set; } 
        public string? SearchTerm { get; set; }
    }
}
