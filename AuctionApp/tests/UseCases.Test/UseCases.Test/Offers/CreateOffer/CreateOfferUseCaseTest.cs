using AuctionApp.API.Communication.Requests;
using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;
using AuctionApp.API.Services;
using AuctionApp.API.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            //ARRANGE
            var request = new Faker<RequestCreateOfferJson>()
                           .RuleFor(request => request.Price, faker => faker.Random.Decimal(1, 700)).Generate();
                                           
            var offersRepositoryMock = new Mock<IOffersRepository>();
            var loggedUserMock = new Mock<ILoggedUser>();

            loggedUserMock.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUserMock.Object, offersRepositoryMock.Object);

            //ACT
            var act = () => useCase.Execute(itemId, request);

            //ASSERT
            act.Should().NotThrow();
        }
    }
}
