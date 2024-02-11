using AuctionApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions options) : base(options)   
        {

        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Offer> Offers { get; set; }        
    }
}
