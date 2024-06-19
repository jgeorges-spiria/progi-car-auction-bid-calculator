using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Domain.BidCalculation
{
	public class BidCalculation
	{
        public double vehiclePrice { get; }
        public VehicleType vehicleType { get; }

        
        public BidCalculation(double vehiclePrice, VehicleType vehicleType) {
            this.vehiclePrice = vehiclePrice;
            this.vehicleType = vehicleType;
        }

        public double getBasicFee()
        {
            double calculatedFee = this.vehiclePrice * BidCalculationFeeParameters.BASIC_FEE_PERCENT;

            if (this.vehicleType == VehicleType.Luxury)
            {
                return this.pickApplicableFee(
                    BidCalculationFeeParameters.BASIC_LUXURY_MIN_FEE,
                    BidCalculationFeeParameters.BASIC_LUXURY_MAX_FEE,
                    calculatedFee);
            }

            return this.pickApplicableFee(
                    BidCalculationFeeParameters.BASIC_COMMON_MIN_FEE,
                    BidCalculationFeeParameters.BASIC_COMMON_MAX_FEE,
                    calculatedFee);
        }

        public double getSpecialFee()
        {
            if (this.vehicleType == VehicleType.Luxury)
            {
                return this.vehiclePrice * BidCalculationFeeParameters.SPECIAL_LUXURY_FEE_PERCENT;
            }

            return this.vehiclePrice * BidCalculationFeeParameters.SPECIAL_COMMON_FEE_PERCENT;
        }

        public double getAssociationFee()
        {
            if (this.vehiclePrice >= 1 && this.vehiclePrice <= 500)
            {
                return 5;
            } else if (this.vehiclePrice > 500 && this.vehiclePrice <= 1000)
            {
                return 10;
            } else if (this.vehiclePrice > 1000 && this.vehiclePrice <= 3000)
            {
                return 15;
            } else
            {
                return 20;
            }

        }

        public double getStorageFee()
        {
            return BidCalculationFeeParameters.STORAGE_FEE_AMOUNT;
        }

        public double getTotal()
        {
            return this.vehiclePrice +
                this.getBasicFee() +
                this.getSpecialFee() +
                this.getAssociationFee() +
                this.getStorageFee();
        }

        private double pickApplicableFee(double minFee, double maxFee, double calculatedFee)
        {
            if (calculatedFee < minFee)
            {
                return minFee;
            }

            if (calculatedFee > maxFee)
            {
                return maxFee;
            }

            return calculatedFee;
        }

    }
}

