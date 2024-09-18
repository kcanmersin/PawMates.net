using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Comments.CreateComment;
using PawMates.Core.Features.Comments.DeleteComment;
using PawMates.Core.Features.Comments.UpdateComment;
using PawMates.Core.Features.Comments.GetAllComments;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ISender _sender;

        public CommentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            var command = request.Adapt<CreateCommentCommand>();
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var command = new DeleteCommentCommand { CommentId = id };
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentRequest request)
        {
            var command = request.Adapt<UpdateCommentCommand>();
            command.CommentId = id;
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments([FromQuery] GetAllCommentsRequest request)
        {
            var query = request.Adapt<GetAllCommentsQuery>();
            var result = await _sender.Send(query);

            return Ok(result);
        }
    }
}
