using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Ads.CreateAdvertisement;
using PawMates.Core.Features.Ads.DeleteAdvertisement;
using PawMates.Core.Features.Ads.GetAllAds;
using PawMates.Core.Features.Ads.UpdateAdvertisement;
using System.Threading.Tasks;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly ISender _sender;

        public AdsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd([FromBody] CreateAdvertisementRequest request)
        {
            var command = request.Adapt<CreateAdvertisementCommand>();

            var result = await _sender.Send(command);

            if (!result.Success)
            {
            return BadRequest(new { message = result.Message }); 
            }

                return Ok(result); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAds([FromQuery] GetAllAdsRequest request)
        {
            var query = request.Adapt<GetAllAdsQuery>(); 
            var result = await _sender.Send(query);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAd(Guid id, [FromBody] UpdateAdvertisementRequest request)
        {
            var command = request.Adapt<UpdateAdvertisementCommand>();
            command.AdvertisementId = id;
            var result = await _sender.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAd([FromBody] DeleteAdvertisementRequest request)
        {
            var command = request.Adapt<DeleteAdvertisementCommand>();
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result);
        }
    }
}
