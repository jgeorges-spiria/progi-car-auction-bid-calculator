using System.Net;
using CarAuctionBidApi.Domain.Vehicle;
using CarAuctionBidApi.Dto.BidCalculationDto;
using Tests.Integration.Resources;
using Tests.Integration.Resources.Mocks;

namespace Tests.Integration
{
    [TestClass]
    public class BidControllerTest
    {
        private static readonly TestApiFactory Factory = new TestApiFactory();
        private static readonly string ApiPath = "/api/v1/bid/calculate";


        [TestMethod]
        public async Task ShouldReturnSuccessResponse()
        {
            HttpClient client = Factory.CreateClient();
            HttpResponseMessage response = await client.PostAsync(ApiPath, Factory.CreateRequestBody(new BidCalculationRequestDto(501, VehicleType.Common)));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            BidCalculationResponseDto result = await Factory.CreateReponsePayload<BidCalculationResponseDto>(response);

            Assert.AreEqual(result.VehiclePrice, 501);
            Assert.AreEqual(result.VehicleType, "common");
            Assert.AreEqual(result.BasicFee, 50);
            Assert.AreEqual(result.SpecialFee, 10.02);
            Assert.AreEqual(result.AssociationFee, 10);
            Assert.AreEqual(result.StorageFee, 100);
            Assert.AreEqual(result.Total, 671.02);

        }


        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1000000000)]
        [DataTestMethod]
        public async Task ShouldReturnBadRequestForInvalidVehiclePriceValue(double vehiclePrice)
        {
            HttpClient client = Factory.CreateClient();
            HttpResponseMessage response = await client.PostAsync(ApiPath, Factory.CreateRequestBody(new BidCalculationRequestDto(vehiclePrice, VehicleType.Common)));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestForInvalidVehicleTypeValue()
        {
            HttpClient client = Factory.CreateClient();
            HttpResponseMessage response = await client.PostAsync(ApiPath, Factory.CreateRequestBody(new MockBidCalculationRequestDto(100, "invalid-vehicle-type")));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Factory.CleanUp();
        }
    }
}

