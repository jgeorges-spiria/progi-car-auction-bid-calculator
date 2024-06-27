using CarAuctionBidApi.Domain.Vehicle;

namespace CarAuctionBidApi.Domain.BidCalculation
{
    public class BidCalculation
    {
        public double VehiclePrice { get; }
        public VehicleType VehicleType { get; }

        private double BASIC_LUXURY_MIN_FEE { get; } = 25;
        private double BASIC_LUXURY_MAX_FEE { get; } = 200;
        private double BASIC_COMMON_MIN_FEE { get; } = 10;
        private double BASIC_COMMON_MAX_FEE { get; } = 50;
        private double BASIC_FEE_PERCENT { get; } = 0.10;
        private double SPECIAL_LUXURY_FEE_PERCENT { get; } = 0.04;
        private double SPECIAL_COMMON_FEE_PERCENT { get; } = 0.02;


        public BidCalculation(double vehiclePrice, VehicleType vehicleType)
        {
            if (vehiclePrice < 1)
            {
                throw new ArgumentException("vehiclePrice must be greater than 0");
            }
            VehiclePrice = vehiclePrice;
            VehicleType = vehicleType;
        }

        public double GetBasicFee()
        {
            double calculatedFee = VehiclePrice * BASIC_FEE_PERCENT;

            if (VehicleType == VehicleType.Luxury)
            {
                return Math.Clamp(
                    calculatedFee,
                    BASIC_LUXURY_MIN_FEE,
                    BASIC_LUXURY_MAX_FEE
                );
            }

            return Math.Clamp(
                calculatedFee,
                BASIC_COMMON_MIN_FEE,
                BASIC_COMMON_MAX_FEE
            );

        }

        public double GetSpecialFee()
        {
            if (VehicleType == VehicleType.Luxury)
            {
                return VehiclePrice * SPECIAL_LUXURY_FEE_PERCENT;
            }

            return VehiclePrice * SPECIAL_COMMON_FEE_PERCENT;
        }

        public double GetAssociationFee()
        {
            if (VehiclePrice >= 1 && VehiclePrice <= 500)
            {
                return 5;
            }
            else if (VehiclePrice > 500 && VehiclePrice <= 1000)
            {
                return 10;
            }
            else if (VehiclePrice > 1000 && VehiclePrice <= 3000)
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
            return 100;
        }

        public double GetTotal()
        {
            return VehiclePrice +
                GetBasicFee() +
                GetSpecialFee() +
                GetAssociationFee() +
                GetStorageFee();
        }

    }
}

