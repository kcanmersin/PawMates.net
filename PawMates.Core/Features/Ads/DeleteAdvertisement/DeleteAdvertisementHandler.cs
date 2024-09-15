using MediatR;
using Pawmates.Core.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using PawMates.Core.Data.Entity.Ads;

namespace PawMates.Core.Features.Ads.DeleteAdvertisement
{
    public class DeleteAdvertisementHandler : IRequestHandler<DeleteAdvertisementCommand, DeleteAdvertisementResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteAdvertisementHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteAdvertisementResponse> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var advertisement = await _context.Set<AdvertisementBase>()
                                                  .FirstOrDefaultAsync(a => a.Id == request.AdvertisementId && a.UserId == request.UserId, cancellationToken);
                if (advertisement == null)
                {
                    return new DeleteAdvertisementResponse
                    {
                        Success = false,
                        Message = "Advertisement not found or you are not authorized to delete it."
                    };
                }

                _context.Set<AdvertisementBase>().Remove(advertisement);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteAdvertisementResponse
                {
                    Success = true,
                    Message = "Advertisement deleted successfully."
                };
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"An error occurred while deleting the advertisement: {ex.Message}, Inner exception: {innerMessage}");

                return new DeleteAdvertisementResponse
                {
                    Success = false,
                    Message = $"An error occurred while deleting the advertisement: {ex.Message}. Inner exception: {innerMessage}"
                };
            }
        }
    }
}
