using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Dto.VehicleTypeDto
{
	public class VehicleTypeDtoMapper
	{

        public static string toString(VehicleType vehicleType)
		{
			if (vehicleType == VehicleType.Luxury)
			{
				return "luxury";
			}

			return "common";
		}
	}
}

