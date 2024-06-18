using System;
namespace CarAuctionBidApi.Domain.BidCalculation
{
	public struct BidCalculationFeeParameters
	{
		public double BASIC_LUXURY_MIN_FEE = 25;
        public double BASIC_LUXURY_MAX_FEE = 200;

        public double BASIC_COMMON_MIN_FEE = 10;
        public double BASIC_COMMON_MAX_FEE = 50;

        public double BASIC_FEE_PERCENT = 0.10;

        public double SPECIAL_LUXURY_FEE_PERCENT = 0.04;
        public double SPECIAL_COMMON_FEE_PERCENT = 0.02;

        public double STORAGE_FEE_AMOUNT = 100;


        public BidCalculationFeeParameters()
        {
        }
    }
}

