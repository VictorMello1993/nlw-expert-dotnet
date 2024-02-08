using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.Repositories.DataAccess
{
    public class AuctionsRepository : IAuctionsRepository
    {
        private readonly AuctionDbContext _dbContext;
        public AuctionsRepository(AuctionDbContext dbContext) => _dbContext = dbContext;    
       
        public Auction? GetCurrent()
        {
            var today = DateTime.Now;

            return _dbContext
                    .Auctions
                    .Include(auction => auction.Items)
                    .FirstOrDefault(auction => today >= auction.Starts && 
                                               today <= auction.Ends.AddMonths(1));
        }
    }
}
