using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;

namespace AuctionApp.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionsRepository _repository;

        public GetCurrentAuctionUseCase(IAuctionsRepository repository) => _repository = repository;  
          
        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
