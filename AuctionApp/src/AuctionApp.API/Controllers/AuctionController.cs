using AuctionApp.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();

            var result = useCase.Execute();

            return Ok(result);
        }
    }
}
