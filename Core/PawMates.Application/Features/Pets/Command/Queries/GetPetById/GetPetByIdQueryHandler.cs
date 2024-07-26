using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PawMates.Application.DTOs;
using PawMates.Application.Interfaces.UnitOfWorks;
using PawMates.Domain.Entities;
using PawMates.Application.Interfaces.AutoMapper;

namespace PawMates.Application.Features.Pets.Queries.GetPetById
{
    public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQueryRequest, GetPetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetPetByIdQueryResponse> Handle(GetPetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Retrieve the pet by ID from the repository
            var pet = await _unitOfWork.GetReadRepository<Pet>().GetAsync(x => x.Id == request.PetId);

            // Map the Pet entity to the GetPetByIdQueryResponse
            var map = _mapper.Map<GetPetByIdQueryResponse, Pet>(pet);

            return map;
        }
    }
}
