using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;

namespace AuctionApp.API.Repositories.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AuctionDbContext _dbContext;

        public UsersRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

        public bool ExistsWithEmail(string email)
        {
            return _dbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users.First(user => user.Email.Equals(email));
        }
    }
}
