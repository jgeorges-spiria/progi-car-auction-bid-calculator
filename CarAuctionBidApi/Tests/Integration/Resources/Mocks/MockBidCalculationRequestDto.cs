namespace Tests.Integration.Resources.Mocks
{
	public class MockBidCalculationRequestDto
	{

        public double VehiclePrice { get; set; }
        public string VehicleType { get; set; }

        public MockBidCalculationRequestDto(double vehiclePrice, string vehicleType)
        {
            this.VehiclePrice = vehiclePrice;
            this.VehicleType = vehicleType;
        }

        
    }
}

