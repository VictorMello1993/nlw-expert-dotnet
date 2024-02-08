using AuctionApp.API.Entities;

namespace AuctionApp.API.Interfaces
{
    public interface IOffersRepository
    {
        void Add(Offer offer);
    }
}
