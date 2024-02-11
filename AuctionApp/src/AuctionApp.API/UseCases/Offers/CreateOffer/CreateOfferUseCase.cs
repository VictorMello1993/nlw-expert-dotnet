using AuctionApp.API.Communication.Requests;
using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;
using AuctionApp.API.Services;

namespace AuctionApp.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOffersRepository _repository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOffersRepository repository)
        {
            _loggedUser = loggedUser;
            _repository = repository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _repository.Add(offer);

            return offer.Id;
        }
    }
}
