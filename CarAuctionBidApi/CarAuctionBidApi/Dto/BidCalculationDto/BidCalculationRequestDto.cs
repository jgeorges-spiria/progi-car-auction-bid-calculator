using System.ComponentModel.DataAnnotations;
using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Dto.BidCalculationDto
{
	public class BidCalculationRequestDto
	{
        [Required, Range(1, 999999999)]
        public double vehiclePrice { get; set; }

        [Required, EnumDataType(typeof(VehicleType))]
        public VehicleType vehicleType { get; set; }

        public BidCalculationRequestDto(double vehiclePrice, VehicleType vehicleType)
		{
			this.vehiclePrice = vehiclePrice;
			this.vehicleType = vehicleType;
		}

		public BidCalculation toBidCalculation()
		{
			return new BidCalculation(this.vehiclePrice, this.vehicleType);
		}
	}
}

