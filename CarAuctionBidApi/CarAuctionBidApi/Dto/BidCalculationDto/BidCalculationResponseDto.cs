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

        public BidCalculationResponseDto(double vehiclePrice, string vehicleType, double basicFee, double specialFee, double associationFee, double storageFee, double total)
        {
            VehiclePrice = vehiclePrice;
            VehicleType = vehicleType;
            BasicFee = basicFee;
            SpecialFee = specialFee;
            AssociationFee = associationFee;
            StorageFee = storageFee;
            Total = total;
        }

    }
}

