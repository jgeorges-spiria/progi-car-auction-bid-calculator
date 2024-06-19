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
            Assert.AreEqual(bidCalculation.vehiclePrice, vehiclePrice);
            Assert.AreEqual(bidCalculation.vehicleType, vehicleType);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor398AndCommon()
        {
            double vehiclePrice = 398;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 39.8, this.assertDelta);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 7.96, this.assertDelta);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 5);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 550.76, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor501AndCommon()
        {
            double vehiclePrice = 501;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 50);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 10.02, this.assertDelta);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 10);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 671.02, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor57AndCommon()
        {
            double vehiclePrice = 57;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 10);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 1.14, this.assertDelta);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 5);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 173.14, this.assertDelta);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1800AndLuxury()
        {
            double vehiclePrice = 1800;
            VehicleType vehicleType = VehicleType.Luxury;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 180);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 72);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 15);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 2167);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1100AndCommon()
        {
            double vehiclePrice = 1100;
            VehicleType vehicleType = VehicleType.Common;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 50);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 22);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 15);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 1287);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesFor1000000AndLuxury()
        {
            double vehiclePrice = 1000000;
            VehicleType vehicleType = VehicleType.Luxury;
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.getBasicFee(), 200);
            Assert.AreEqual(bidCalculation.getSpecialFee(), 40000);
            Assert.AreEqual(bidCalculation.getAssociationFee(), 20);
            Assert.AreEqual(bidCalculation.getStorageFee(), 100);
            Assert.AreEqual(bidCalculation.getTotal(), 1040320);
        }
    }
}

