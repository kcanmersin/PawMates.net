using MediatR;
using PawMates.Application.Interfaces.UnitOfWorks;
using PawMates.Application.Interfaces.AutoMapper;
using PawMates.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using PawMates.Application.Features.Ads.LostAds.Command.CreateLostAd;

namespace PawMates.Application.Features.Ads.LostAds.Command.CreateLostAd
{
    public class CreateLostAdCommandHandler : IRequestHandler<CreateLostAdCommandRequest, CreateLostAdCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLostAdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateLostAdCommandResponse> Handle(CreateLostAdCommandRequest request, CancellationToken cancellationToken)
        {
            var lostAd = new LostAd
            {
                Title = request.Title,
                Description = request.Description,
                LastSeenLocation = request.LastSeenLocation,
                LastSeenTime = request.LastSeenTime,
                Pets = _mapper.Map<List<Pet>>(request.Pets)
            };

            await _unitOfWork.GetWriteRepository<LostAd>().AddAsync(lostAd);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CreateLostAdCommandResponse,LostAd>(lostAd);
        }
    }
}
