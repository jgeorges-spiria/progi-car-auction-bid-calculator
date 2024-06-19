import { BidCalculationResponseDto } from "../../../api/car-auction-bid-api/dto/bid-calculation-response.dto";
import { CarAuctionBidApiDtoMapper } from "../../../api/car-auction-bid-api/dto/car-auction-bid-api-dto-mapper";
import { BidCalculation } from "../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";

describe("CarAuctionBidApiDtoMapper", () => {
  let bidCalculationResponseDto: BidCalculationResponseDto;

  beforeEach(() => {
    bidCalculationResponseDto = {
      vehiclePrice: 398,
      vehicleType: "common",
      basicFee: 39.8,
      specialFee: 7.96,
      associationFee: 5,
      storageFee: 100,
      total: 550.76,
    };
  });

  describe("mapToBidCalculation", () => {
    it("should map a BidCalculationResponseDto to a BidCalculation model", () => {
      const expected: BidCalculation = {
        vehiclePrice: 398,
        vehicleType: VehicleType.Common,
        basicFee: 39.8,
        specialFee: 7.96,
        associationFee: 5,
        storageFee: 100,
        total: 550.76,
      };
      expect(
        CarAuctionBidApiDtoMapper.mapToBidCalculation(
          bidCalculationResponseDto,
        ),
      ).toStrictEqual(expected);
    });
  });

  describe("mapToVehicleType", () => {
    it("should map a vehicleTypeDto: 'common' to a VehicleType.Common", () => {
      expect(CarAuctionBidApiDtoMapper.mapToVehicleType("common")).toBe(
        VehicleType.Common,
      );
    });
    it("should map a vehicleTypeDto: 'luxury' to a VehicleType.Luxury", () => {
      expect(CarAuctionBidApiDtoMapper.mapToVehicleType("luxury")).toBe(
        VehicleType.Luxury,
      );
    });
  });
});
