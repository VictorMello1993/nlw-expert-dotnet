using AuctionApp.API.Entities;
using AuctionApp.API.Enums;
using AuctionApp.API.Interfaces;
using AuctionApp.API.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //ARRANGE            
            var entity = new Faker<Auction>().RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 9999))
                                             .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
                                             .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
                                             .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
                                             .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>
                                             {
                                                 new Item
                                                 {
                                                     Id = faker.Random.Number(1, 9999),
                                                     Name = faker.Commerce.ProductName(),
                                                     Brand = faker.Commerce.Department(),
                                                     BasePrice = faker.Random.Decimal(50, 1000),
                                                     Condition = faker.PickRandom<Condition>(),
                                                     AuctionId = auction.Id
                                                 }
                                             })
                                             .Generate();

            var auctionsRepositoryMock = new Mock<IAuctionsRepository>();
            auctionsRepositoryMock.Setup(i => i.GetCurrent()).Returns(entity);

            var useCase = new GetCurrentAuctionUseCase(auctionsRepositoryMock.Object);            

            //ACT
            var auction = useCase.Execute();

            //ASSERT
            auction.Should().NotBeNull();
            auction!.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);
        }
    }
}
