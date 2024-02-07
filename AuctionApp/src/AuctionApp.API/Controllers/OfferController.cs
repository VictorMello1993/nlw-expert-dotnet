using AuctionApp.API.Communication.Requests;
using AuctionApp.API.Filters;
using AuctionApp.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttributes))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer(
            [FromRoute]int itemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}
