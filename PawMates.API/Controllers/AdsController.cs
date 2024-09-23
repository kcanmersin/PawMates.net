using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Ads.CreateAdvertisement;
using PawMates.Core.Features.Ads.DeleteAdvertisement;
using PawMates.Core.Features.Ads.GetAllAds;
using PawMates.Core.Features.Ads.UpdateAdvertisement;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAd([FromForm] CreateAdvertisementRequest request, [FromForm] List<IFormFile> advertisementImages)
        {
            var command = request.Adapt<CreateAdvertisementCommand>();

            command.AdvertisementImages = advertisementImages;

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAd(Guid id, [FromForm] UpdateAdvertisementRequest request, [FromForm] List<IFormFile> advertisementImages)
        {
            var command = request.Adapt<UpdateAdvertisementCommand>();

            command.AdvertisementImages = advertisementImages;
            command.AdvertisementId = id;

            // Send the command to the handler
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
