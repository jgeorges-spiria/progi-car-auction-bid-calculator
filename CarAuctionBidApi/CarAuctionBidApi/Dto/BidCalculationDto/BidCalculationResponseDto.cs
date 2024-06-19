using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Dto.VehicleTypeDto;

namespace CarAuctionBidApi.Dto.BidCalculationDto
{
	public class BidCalculationResponseDto
	{
        public double VehiclePrice { get; }
        public string VehicleType { get; }
        public double BasicFee { get; }
        public double SpecialFee { get; }
        public double AssociationFee { get; }
        public double StorageFee { get; }
        public double Total { get; }

        public static BidCalculationResponseDto Create(BidCalculation bidCalculation)
		{
            return new BidCalculationResponseDto(
                bidCalculation.VehiclePrice,
                VehicleTypeDtoMapper.ToString(bidCalculation.VehicleType),
                bidCalculation.GetBasicFee(),
                bidCalculation.GetSpecialFee(),
                bidCalculation.GetAssociationFee(),
                bidCalculation.GetStorageFee(),
                bidCalculation.GetTotal()
                );
        }

        public BidCalculationResponseDto(double vehiclePrice, string vehicleType, double basicFee, double specialFee, double associationFee, double storageFee, double total) {
            this.VehiclePrice = vehiclePrice;
            this.VehicleType = vehicleType;
            this.BasicFee = basicFee;
            this.SpecialFee = specialFee;
            this.AssociationFee = associationFee;
            this.StorageFee = storageFee;
            this.Total = total;
        }

    }
}

