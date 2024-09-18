namespace PawMates.API.Contracts
{
    public class GetAllCommentsRequest
    {
        public Guid? AdvertisementId { get; set; }
        public Guid? PostId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
