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
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfVehiclePriceIs0()
        {
            new BidCalculation(0, VehicleType.Common);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfVehiclePriceIsLessThan0()
        {
            new BidCalculation(-1, VehicleType.Common);
        }

        [DataRow(100, VehicleType.Luxury, 25)]
        [DataRow(300, VehicleType.Luxury, 30)]
        [DataRow(50000, VehicleType.Luxury, 200)]
        [DataRow(100, VehicleType.Common, 10)]
        [DataRow(300, VehicleType.Common, 30)]
        [DataRow(50000, VehicleType.Common, 50)]
        [DataTestMethod]
        public void BasicFeeCalculationTest(double vehiclePrice, VehicleType vehicleType, double expectedBasicFeeAmount)
        {
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetBasicFee(), expectedBasicFeeAmount);
        }

        [DataRow(1000, VehicleType.Luxury, 40)]
        [DataRow(1000, VehicleType.Common, 20)]
        [DataTestMethod]
        public void SpecialFeeCalculationTest(double vehiclePrice, VehicleType vehicleType, double expectedSpecialFeeAmount)
        {
            BidCalculation bidCalculation = new BidCalculation(vehiclePrice, vehicleType);
            Assert.AreEqual(bidCalculation.GetSpecialFee(), expectedSpecialFeeAmount);
        }

        [DataRow(1, 5)]
        [DataRow(10, 5)]
        [DataRow(500, 5)]
        [DataRow(501, 10)]
        [DataRow(510, 10)]
        [DataRow(1000, 10)]
        [DataRow(1001, 15)]
        [DataRow(1010, 15)]
        [DataRow(3000, 15)]
        [DataRow(3001, 20)]
        [DataRow(20000, 20)]
        [DataTestMethod]
        public void AssociationFeeCalculationTest(double vehiclePrice, double expectedAssociationFeeAmount)
        {
            BidCalculation commonBidCalculation = new BidCalculation(vehiclePrice, VehicleType.Common);
            BidCalculation luxuryBidCalculation = new BidCalculation(vehiclePrice, VehicleType.Luxury);

            Assert.AreEqual(commonBidCalculation.GetAssociationFee(), expectedAssociationFeeAmount);
            Assert.AreEqual(luxuryBidCalculation.GetAssociationFee(), expectedAssociationFeeAmount);
        }


        [TestMethod]
        public void StorageFeeShouldAlwaysReturn100()
        {
            double expectedStorageFee = 100;
            BidCalculation commonBidCalculation = new BidCalculation(10000, VehicleType.Common);
            BidCalculation luxuryBidCalculation = new BidCalculation(1000000, VehicleType.Luxury);

            Assert.AreEqual(commonBidCalculation.GetStorageFee(), expectedStorageFee);
            Assert.AreEqual(luxuryBidCalculation.GetStorageFee(), expectedStorageFee);
        }

        [TestMethod]
        public void TotalCalculationTest()
        {

            BidCalculation bidCalculation = new BidCalculation(10000, VehicleType.Common);
            double expectedTotal = bidCalculation.VehiclePrice +
                bidCalculation.GetBasicFee() +
                bidCalculation.GetSpecialFee() +
                bidCalculation.GetAssociationFee() +
                bidCalculation.GetStorageFee();

            Assert.AreEqual(bidCalculation.GetTotal(), expectedTotal);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectFeesAndTotalFor398AndCommon()
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
        public void ShouldReturnTheCorrectFeesAndTotalFor501AndCommon()
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
        public void ShouldReturnTheCorrectFeesAndTotalFor57AndCommon()
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
        public void ShouldReturnTheCorrectFeesAndTotalFor1800AndLuxury()
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
        public void ShouldReturnTheCorrectFeesAndTotalFor1100AndCommon()
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
        public void ShouldReturnTheCorrectFeesAndTotalFor1000000AndLuxury()
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

