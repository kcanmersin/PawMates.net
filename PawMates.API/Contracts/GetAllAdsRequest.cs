using PawMates.Core.Data.Entity.Ads;

namespace PawMates.Core.Features.Ads.GetAllAds
{
    public class GetAllAdsRequest
    {
        public int PageNumber { get; set; } = 1;  
        public int PageSize { get; set; } = 10;   
        public AdvertisementType? AdType { get; set; }

        public string? SearchTerm { get; set; }
    }
}
