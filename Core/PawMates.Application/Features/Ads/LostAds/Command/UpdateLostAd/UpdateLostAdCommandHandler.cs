using MediatR;
using PawMates.Application.Interfaces.UnitOfWorks;
using PawMates.Application.Interfaces.AutoMapper;
using PawMates.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using PawMates.Application.Features.Ads.LostAds.Commands.UpdateLostAd;

namespace PawMates.Application.Features.Ads.LostAds.Commands.UpdateLostAd
{
    public class UpdateLostAdCommandHandler : IRequestHandler<UpdateLostAdCommandRequest, UpdateLostAdCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLostAdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateLostAdCommandResponse> Handle(UpdateLostAdCommandRequest request, CancellationToken cancellationToken)
        {
            var lostAd = await _unitOfWork.GetReadRepository<LostAd>().GetAsync(ad => ad.Id == request.Id);

            if (lostAd == null)
            {
                // Handle not found case
                return null;
            }

            lostAd.Title = request.Title;
            lostAd.Description = request.Description;
            lostAd.LastSeenLocation = request.LastSeenLocation;
            lostAd.LastSeenTime = request.LastSeenTime;
            lostAd.Pets = _mapper.Map<List<Pet>>(request.Pets);

            await _unitOfWork.GetWriteRepository<LostAd>().UpdateAsync(lostAd);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UpdateLostAdCommandResponse>(lostAd);
        }
    }
}
