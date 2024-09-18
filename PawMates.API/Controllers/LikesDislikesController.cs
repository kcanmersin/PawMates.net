using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.LikesDislikes.CreateLikeDislike;
using PawMates.Core.Features.LikesDislikes.DeleteLikeDislike;
using PawMates.Core.Features.LikesDislikes.GetAllLikesDislikes;
using System.Threading.Tasks;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesDislikesController : ControllerBase
    {
        private readonly ISender _sender;

        public LikesDislikesController(ISender sender)
        {
            _sender = sender;
        }

        // POST: api/LikesDislikes
        [HttpPost]
        public async Task<IActionResult> CreateLikeDislike([FromBody] CreateLikeDislikeRequest request)
        {
            var command = request.Adapt<CreateLikeDislikeCommand>();
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // DELETE: api/LikesDislikes/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteLikeDislike([FromBody] DeleteLikeDislikeRequest request)
        {
            var command = request.Adapt<DeleteLikeDislikeCommand>();
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // GET: api/LikesDislikes?postId={postId}&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllLikesDislikes([FromQuery] GetAllLikesDislikesRequest request)
        {
            var query = request.Adapt<GetAllLikesDislikesQuery>();
            var result = await _sender.Send(query);

            return Ok(result);
        }
    }
}