using CarAuctionBidApi.Domain.BidCalculation;
using CarAuctionBidApi.Domain.Vehicle;

namespace Tests.Domain.BidCalculationTest
{
    [TestClass]
    public class BidCalculationTest
	{
        private double assertDelta = 0.00001;

        [TestMethod]
        public void ShouldSetTheVehiclePriceAndVehicleType()
		{
            double vehiclePrice = 500;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.VehiclePrice, vehiclePrice);
            Assert.AreEqual(bidCalculation.VehicleType, vehicleType);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor398AndCommon()
        {
            double vehiclePrice = 398;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 39.8, this.assertDelta);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 7.96, this.assertDelta);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 5);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 550.76, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor501AndCommon()
        {
            double vehiclePrice = 501;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 50);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 10.02, this.assertDelta);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 10);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 671.02, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor57AndCommon()
        {
            double vehiclePrice = 57;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 10);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 1.14, this.assertDelta);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 5);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 173.14, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1800AndLuxury()
        {
            double vehiclePrice = 1800;
            VehicleType vehicleType = VehicleType.Luxury;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 180);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 72);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 15);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 2167);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1100AndCommon()
        {
            double vehiclePrice = 1100;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 50);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 22);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 15);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 1287);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1000000AndLuxury()
        {
            double vehiclePrice = 1000000;
            VehicleType vehicleType = VehicleType.Luxury;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), 200);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), 40000);
            Assert.AreEqual(bidCalculation.GetAssociationFee(), 20);
            Assert.AreEqual(bidCalculation.GetStorageFee(), 100);
            Assert.AreEqual(bidCalculation.GetTotal(), 1040320);
        }
    }
}

