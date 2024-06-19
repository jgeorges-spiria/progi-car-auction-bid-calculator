using System.Text.Json.Serialization;

namespace CarAuctionBidApi.Domain.Vehicle
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleType
	{
		Common,
		Luxury
	}
}