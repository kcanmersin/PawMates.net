using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Posts.CreatePost;
using PawMates.Core.Features.Posts.DeletePost;
using PawMates.Core.Features.Posts.GetAllPosts;
using PawMates.Core.Features.Posts.UpdatePost;
using System.Threading.Tasks;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ISender _sender;

        public PostsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var command = request.Adapt<CreatePostCommand>();
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsRequest request)
        {
            var query = request.Adapt<GetAllPostsQuery>();  
            var result = await _sender.Send(query);  

            return Ok(result);  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] UpdatePostRequest request)
        {
            var command = request.Adapt<UpdatePostCommand>();
            command.PostId = id;  // Set the PostId from the URL
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var command = new DeletePostCommand { PostId = id };
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
