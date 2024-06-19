using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Dto.VehicleTypeDto;

namespace CarAuctionBidApi.Dto.BidCalculationDto
{
	public class BidCalculationResponseDto
	{
        public double vehiclePrice { get; }
        public string vehicleType { get; }
        public double basicFee { get; }
        public double specialFee { get; }
        public double associationFee { get; }
        public double storageFee { get; }
        public double total { get; }

        public static BidCalculationResponseDto create(BidCalculation bidCalculation)
		{
            return new BidCalculationResponseDto(
                bidCalculation.vehiclePrice,
                VehicleTypeDtoMapper.toString(bidCalculation.vehicleType),
                bidCalculation.getBasicFee(),
                bidCalculation.getSpecialFee(),
                bidCalculation.getAssociationFee(),
                bidCalculation.getStorageFee(),
                bidCalculation.getTotal()
                );
        }

        public BidCalculationResponseDto(double vehiclePrice, string vehicleType, double basicFee, double specialFee, double associationFee, double storageFee, double total) {
            this.vehiclePrice = vehiclePrice;
            this.vehicleType = vehicleType;
            this.basicFee = basicFee;
            this.specialFee = specialFee;
            this.associationFee = associationFee;
            this.storageFee = storageFee;
            this.total = total;
        }

    }
}

