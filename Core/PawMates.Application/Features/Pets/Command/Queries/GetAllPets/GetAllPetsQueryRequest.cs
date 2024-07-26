
using MediatR;
namespace PawMates.Application.Features.Pets.Command.Queries.GetAllPets
{
    public class GetAllPetsQueryRequest : IRequest<IList<GetAllPetsQueryResponse>>
    {
      
    }
}