using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.API.Contracts;
using PawMates.Core.Features.Comments.CreateComment;
using PawMates.Core.Features.Comments.DeleteComment;
using PawMates.Core.Features.Comments.UpdateComment;
using PawMates.Core.Features.Comments.GetAllComments;
using Microsoft.AspNetCore.Http; // For handling IFormFile
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        // Create a new comment with media support (images/videos)
        [HttpPost]
        [Consumes("multipart/form-data")] // Ensure Swagger understands this is a form-data request
        public async Task<IActionResult> CreateComment([FromForm] CreateCommentRequest request, [FromForm] List<IFormFile> commentMedia)
        {
            var command = request.Adapt<CreateCommentCommand>();
            command.CommentMedia = commentMedia; // Add media to the command
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromForm] UpdateCommentRequest request, [FromForm] List<IFormFile> commentMedia)
        {
            var command = request.Adapt<UpdateCommentCommand>();
            command.CommentId = id;
            command.CommentMedia = commentMedia; 
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

        [HttpGet]
        public async Task<IActionResult> GetAllComments([FromQuery] GetAllCommentsRequest request)
        {
            var query = request.Adapt<GetAllCommentsQuery>();
            var result = await _sender.Send(query);

            return Ok(result);
        }
    }
}
