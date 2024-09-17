using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<PaginatedPostsResponse>
    {
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10;  
        public string? SearchTerm { get; set; }  
    }
}
