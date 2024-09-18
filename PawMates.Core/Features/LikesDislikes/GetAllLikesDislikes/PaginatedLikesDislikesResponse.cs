using System.Collections.Generic;

namespace PawMates.Core.Features.LikesDislikes.GetAllLikesDislikes
{
    public class PaginatedLikesDislikesResponse
    {
        public List<LikeDislikeDto> LikesDislikes { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
