using AuctionApp.API.Entities;

namespace AuctionApp.API.Interfaces
{
    public interface IAuctionsRepository 
    {
        Auction? GetCurrent();
    }
}
