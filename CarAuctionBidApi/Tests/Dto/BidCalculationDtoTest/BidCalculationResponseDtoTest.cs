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
            BidCalculationResponseDto dto = BidCalculationResponseDto.Create(bidCalculation);

            Assert.AreEqual(dto.VehiclePrice, bidCalculation.VehiclePrice);
            Assert.AreEqual(dto.VehicleType, "common");
            Assert.AreEqual(dto.BasicFee, bidCalculation.GetBasicFee());
            Assert.AreEqual(dto.SpecialFee, bidCalculation.GetSpecialFee());
            Assert.AreEqual(dto.AssociationFee, bidCalculation.GetAssociationFee());
            Assert.AreEqual(dto.StorageFee, bidCalculation.GetStorageFee());
            Assert.AreEqual(dto.Total, bidCalculation.GetTotal());
        }
	}
}

