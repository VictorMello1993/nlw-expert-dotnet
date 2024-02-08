using AuctionApp.API.Entities;

namespace AuctionApp.API.Interfaces
{
    public interface IUsersRepository
    {
        bool ExistsWithEmail(string email);
        User GetByEmail(string email);
    }
}
