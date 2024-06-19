using CarAuctionBidApi.Dto.BidCalculationDto;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionBidApi.Controllers;

[ApiController]
[Route("api/v1/bid/[action]")]
public class BidController : ControllerBase
{

    [HttpPost]
    [ActionName("calculate")]
    public BidCalculationResponseDto Calculate(BidCalculationRequestDto bidCalculationRequestDto)
    {
        return BidCalculationResponseDto.Create(bidCalculationRequestDto.ToBidCalculation());
    }
}

