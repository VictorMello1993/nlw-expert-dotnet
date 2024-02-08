using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;

namespace AuctionApp.API.Repositories.DataAccess
{
    public class OffersRepository : IOffersRepository
    {
        private readonly AuctionDbContext _dbContext;
        public OffersRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}
