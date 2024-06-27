using System.ComponentModel.DataAnnotations;
using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Dto.BidCalculationDto
{
    public class BidCalculationRequestDto
    {
        [Required, Range(1, 999999999)]
        public double VehiclePrice { get; set; }

        [Required, EnumDataType(typeof(VehicleType))]
        public VehicleType VehicleType { get; set; }

        public BidCalculationRequestDto(double vehiclePrice, VehicleType vehicleType)
        {
            VehiclePrice = vehiclePrice;
            VehicleType = vehicleType;
        }

        public BidCalculation ToBidCalculation()
        {
            return new BidCalculation(VehiclePrice, VehicleType);
        }
    }
}

