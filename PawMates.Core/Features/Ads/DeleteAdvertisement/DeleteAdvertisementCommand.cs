using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Ads.DeleteAdvertisement
{
    public class DeleteAdvertisementCommand : IRequest<DeleteAdvertisementResponse>
    {
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
    }
}
