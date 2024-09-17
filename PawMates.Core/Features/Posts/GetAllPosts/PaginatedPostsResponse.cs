using PawMates.Core.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.GetAllPosts
{
    public class PaginatedPostsResponse
    {
        public List<PostDto> Posts { get; set; } = new List<PostDto>();  
        public int TotalCount { get; set; }  
        public int CurrentPage { get; set; } 
        public int PageSize { get; set; }     
        public int TotalPages { get; set; } 
    }
}
