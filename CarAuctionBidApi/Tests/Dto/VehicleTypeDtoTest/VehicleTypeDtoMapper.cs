using CarAuctionBidApi.Domain.Vehicle;
using CarAuctionBidApi.Dto.VehicleTypeDto;

namespace Tests.Dto.VehicleTypeDtoTest
{
    [TestClass]
    public class VehicleTypeDtoTest
	{
        [TestMethod]
        public void ShouldConvertLuxuryVehicleTypeToLuxuryString()
		{
            Assert.AreEqual(VehicleTypeDtoMapper.toString(VehicleType.Luxury), "luxury");
		}

        [TestMethod]
        public void ShouldConvertCommonVehicleTypeToCommonString()
        {
            Assert.AreEqual(VehicleTypeDtoMapper.toString(VehicleType.Common), "common");
        }
    }
}