using AuctionApp.API.Entities;
using AuctionApp.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction Execute()
        {
            var repository = new AuctionDbContext();

            return repository
                    .Auctions
                    .Include(auction => auction.Items)
                    .First();
        }
    }
}
