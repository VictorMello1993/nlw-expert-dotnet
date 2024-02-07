using AuctionApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Especificar o caminho físico do arquivo .db
            optionsBuilder.UseSqlite(@"Data Source=D:\Projetos\nlw-expert-dotnet\AuctionApp\leilaoDbNLW.db");
        }
    }
}
