using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.Application.Interfaces.UnitOfWorks;
using PawMates.Application.Interfaces.AutoMapper;
using PawMates.Domain.Entities;
using MediatR;
namespace PawMates.Application.Features.Pets.Command.Queries.GetAllPets
{

    public class GetAllPetsQueryHandler : IRequestHandler<GetAllPetsQueryRequest, IList<GetAllPetsQueryResponse>>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public GetAllPetsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IList<GetAllPetsQueryResponse>> Handle(GetAllPetsQueryRequest request, CancellationToken cancellationToken)
        {
            var pets = await _unitOfWork.GetReadRepository<Pet>().GetAllAsync();

            //log all pets
            //log pets
            //System.Console.WriteLine(pets.);
            //print pet names
            System.Console.WriteLine(pets.Select(p => p.Name).ToList());

     var map = _mapper.Map<GetAllPetsQueryResponse, Pet>(pets);
            return map;
        }
    }
}