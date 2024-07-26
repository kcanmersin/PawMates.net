using MediatR;

namespace PawMates.Application.Features.Pets.Queries.GetPetById
{
    public class GetPetByIdQueryRequest : IRequest<GetPetByIdQueryResponse>
    {
        public int PetId { get; set; }
    }

}
