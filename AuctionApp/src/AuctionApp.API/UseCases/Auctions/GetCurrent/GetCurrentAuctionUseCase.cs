using AuctionApp.API.Entities;
using AuctionApp.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction? Execute()
        {
            var repository = new AuctionDbContext();

            var today = DateTime.Now;

            return repository
                    .Auctions
                    .Include(auction => auction.Items)
                    .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends.AddMonths(1));
        }
    }
}
