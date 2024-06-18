using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Domain.BidCalculation
{
	public class BidCalculation
	{
        public double vehiclePrice;
        public VehicleType vehicleType;
        private BidCalculationFeeParameters bidCalculationFeeParameters;
        
        public BidCalculation(double vehiclePrice, VehicleType vehicleType) {
            this.vehiclePrice = vehiclePrice;
            this.vehicleType = vehicleType;
            this.bidCalculationFeeParameters = new BidCalculationFeeParameters();
        }

        public double getBasicFee()
        {
            if (this.vehicleType == VehicleType.Luxury)
            {
                return this.getApplicableFee(
                    this.bidCalculationFeeParameters.BASIC_LUXURY_MIN_FEE,
                    this.bidCalculationFeeParameters.BASIC_LUXURY_MAX_FEE,
                    this.vehiclePrice * this.bidCalculationFeeParameters.BASIC_FEE_PERCENT);
            }

            return this.getApplicableFee(
                    this.bidCalculationFeeParameters.BASIC_COMMON_MIN_FEE,
                    this.bidCalculationFeeParameters.BASIC_COMMON_MAX_FEE,
                    this.vehiclePrice * this.bidCalculationFeeParameters.BASIC_FEE_PERCENT);
        }

        public double getSpecialFee()
        {
            if (this.vehicleType == VehicleType.Luxury)
            {
                return this.vehiclePrice * this.bidCalculationFeeParameters.SPECIAL_LUXURY_FEE_PERCENT;
            }

            return this.vehiclePrice * this.bidCalculationFeeParameters.SPECIAL_COMMON_FEE_PERCENT;
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
            return this.bidCalculationFeeParameters.STORAGE_FEE_AMOUNT;
        }

        public double getTotal()
        {
            return this.vehiclePrice +
                this.getBasicFee() +
                this.getSpecialFee() +
                this.getAssociationFee() +
                this.getStorageFee();
        }

        private double getApplicableFee(double minFee, double maxFee, double calculatedFee)
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

