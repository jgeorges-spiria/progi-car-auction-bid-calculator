using System;
namespace CarAuctionBidApi.Domain.BidCalculation
{
	public struct BidCalculationFeeParameters
	{
		public static double BASIC_LUXURY_MIN_FEE { get; } = 25;
        public static double BASIC_LUXURY_MAX_FEE { get; } = 200;

        public static double BASIC_COMMON_MIN_FEE { get; } = 10;
        public static double BASIC_COMMON_MAX_FEE { get; } = 50;

        public static double BASIC_FEE_PERCENT { get; } = 0.10;

        public static double SPECIAL_LUXURY_FEE_PERCENT { get; } = 0.04;
        public static double SPECIAL_COMMON_FEE_PERCENT { get; } = 0.02;

        public static double STORAGE_FEE_AMOUNT { get; } = 100;

    }
}

