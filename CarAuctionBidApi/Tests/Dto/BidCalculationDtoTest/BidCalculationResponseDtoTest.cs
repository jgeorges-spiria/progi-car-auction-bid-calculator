using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Domain.Vehicle;
using CarAuctionBidApi.Dto.BidCalculationDto;

namespace Tests.Dto.BidCalculationDtoTest
{
    [TestClass]
    public class BidCalculationResponseDtoTest
	{
        [TestMethod]
        public void ShouldCreateBidCalculationResponseDtoFromBidCalculation()
		{
            BidCalculation bidCalculation = new BidCalculation(500, VehicleType.Common);
            BidCalculationResponseDto dto = BidCalculationResponseDto.create(bidCalculation);

            Assert.AreEqual(dto.vehiclePrice, bidCalculation.vehiclePrice);
            Assert.AreEqual(dto.vehicleType, "common");
            Assert.AreEqual(dto.basicFee, bidCalculation.getBasicFee());
            Assert.AreEqual(dto.specialFee, bidCalculation.getSpecialFee());
            Assert.AreEqual(dto.associationFee, bidCalculation.getAssociationFee());
            Assert.AreEqual(dto.storageFee, bidCalculation.getStorageFee());
            Assert.AreEqual(dto.total, bidCalculation.getTotal());
        }
	}
}

