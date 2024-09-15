using System;

namespace PawMates.Core.Features.Ads.CreateAdvertisement
{
    public class CreateAdvertisementResponse
    {
        public Guid AdvertisementId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
