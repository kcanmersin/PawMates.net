using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using PawMates.Application.Features.Pets.Queries.GetPetById;
using PawMates.Application.Features.Pets.Commands.CreatePet;
using PawMates.Application.Features.Pets.Command.Queries.GetAllPets;

namespace PawMates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Endpoint to create a new pet
        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody] CreatePetCommandRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // Endpoint to retrieve a pet by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById([FromRoute] int id)
        {
            var query = new GetPetByIdQueryRequest { PetId = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // Endpoint to retrieve all pets
        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var query = new GetAllPetsQueryRequest();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
