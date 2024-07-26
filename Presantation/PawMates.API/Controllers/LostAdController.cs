using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawMates.Application.Features.Ads.LostAds.Command.CreateLostAd;
using PawMates.Application.Features.Ads.LostAds.Commands.UpdateLostAd;
using System;
using System.Threading.Tasks;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LostAdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LostAdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLostAd([FromBody] CreateLostAdCommandRequest command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLostAdById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLostAd(int id, [FromBody] UpdateLostAdCommandRequest command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLostAdById(Guid id)
        {
            // Implementation for getting LostAd by id.
            return Ok();
        }
    }
}
