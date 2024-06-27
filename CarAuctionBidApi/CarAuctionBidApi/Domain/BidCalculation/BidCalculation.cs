using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Domain.BidCalculation
{
    public class BidCalculation
    {
        public double VehiclePrice { get; }
        public VehicleType VehicleType { get; }


        public BidCalculation(double vehiclePrice, VehicleType vehicleType)
        {
            this.VehiclePrice = vehiclePrice;
            this.VehicleType = vehicleType;
        }

        public double GetBasicFee()
        {
            double calculatedFee = this.VehiclePrice * BidCalculationFeeParameters.BASIC_FEE_PERCENT;

            if (this.VehicleType == VehicleType.Luxury)
            {
                return Math.Clamp(
                    calculatedFee,
                    BidCalculationFeeParameters.BASIC_LUXURY_MIN_FEE,
                    BidCalculationFeeParameters.BASIC_LUXURY_MAX_FEE
                );
            }

            return Math.Clamp(
                calculatedFee,
                BidCalculationFeeParameters.BASIC_COMMON_MIN_FEE,
                BidCalculationFeeParameters.BASIC_COMMON_MAX_FEE
            );

        }

        public double GetSpecialFee()
        {
            if (this.VehicleType == VehicleType.Luxury)
            {
                return this.VehiclePrice * BidCalculationFeeParameters.SPECIAL_LUXURY_FEE_PERCENT;
            }

            return this.VehiclePrice * BidCalculationFeeParameters.SPECIAL_COMMON_FEE_PERCENT;
        }

        public double GetAssociationFee()
        {
            if (this.VehiclePrice >= 1 && this.VehiclePrice <= 500)
            {
                return 5;
            }
            else if (this.VehiclePrice > 500 && this.VehiclePrice <= 1000)
            {
                return 10;
            }
            else if (this.VehiclePrice > 1000 && this.VehiclePrice <= 3000)
            {
                return 15;
            }
            else
            {
                return 20;
            }

        }

        public double GetStorageFee()
        {
            return BidCalculationFeeParameters.STORAGE_FEE_AMOUNT;
        }

        public double GetTotal()
        {
            return this.VehiclePrice +
                this.GetBasicFee() +
                this.GetSpecialFee() +
                this.GetAssociationFee() +
                this.GetStorageFee();
        }

    }
}

