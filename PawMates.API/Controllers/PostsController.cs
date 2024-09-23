using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Posts.CreatePost;
using PawMates.Core.Features.Posts.DeletePost;
using PawMates.Core.Features.Posts.GetAllPosts;
using PawMates.Core.Features.Posts.UpdatePost;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostRequest request, [FromForm] List<IFormFile> postMedia)
        {
            var command = request.Adapt<CreatePostCommand>();

            command.PostMedias = postMedia;

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromForm] UpdatePostRequest request, [FromForm] List<IFormFile> postMedia)
        {
            var command = request.Adapt<UpdatePostCommand>();
            command.PostId = id; 

            command.PostMedias = postMedia;

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
