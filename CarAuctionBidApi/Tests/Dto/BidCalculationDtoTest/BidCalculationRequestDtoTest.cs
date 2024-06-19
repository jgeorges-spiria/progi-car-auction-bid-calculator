using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Domain.Vehicle;
using CarAuctionBidApi.Dto.BidCalculationDto;

namespace Tests.Dto.BidCalculationDtoTest
{
    [TestClass]
    public class BidCalculationRequestDtoTest
	{
        [TestMethod]
        public void ShouldConvertToBidCalculationWithTheDtoInputs()
		{
            double vehiclePrice = 500;
            VehicleType vehicleType = VehicleType.Common;

            BidCalculationRequestDto dto = new BidCalculationRequestDto(vehiclePrice, vehicleType);
            BidCalculation bidCalculation = dto.toBidCalculation();

            Assert.AreEqual(dto.vehiclePrice, bidCalculation.vehiclePrice);
            Assert.AreEqual(dto.vehicleType, bidCalculation.vehicleType);
        }
	}
}

