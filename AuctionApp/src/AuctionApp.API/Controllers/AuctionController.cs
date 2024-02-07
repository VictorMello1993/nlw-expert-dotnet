using AuctionApp.API.Entities;
using AuctionApp.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();

            var result = useCase.Execute();

            if(result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
