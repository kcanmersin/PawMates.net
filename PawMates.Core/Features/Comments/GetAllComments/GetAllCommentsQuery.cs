using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<PaginatedCommentsResponse>
    {
        public Guid? AdvertisementId { get; set; }
        public Guid? PostId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
