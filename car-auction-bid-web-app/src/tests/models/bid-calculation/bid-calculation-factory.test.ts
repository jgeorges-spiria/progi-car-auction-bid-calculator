import { BidCalculationFactory } from "../../../models/bid-calculation/bid-calculation.factory";
import { BidCalculation } from "../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";

describe("BidCalculationFactory", () => {
  describe("createDefault", () => {
    it("should return a BidCalculation with zeroed values and common vehicle-type", () => {
      const expected: BidCalculation = {
        vehiclePrice: 0,
        vehicleType: VehicleType.Common,
        basicFee: 0,
        specialFee: 0,
        associationFee: 0,
        storageFee: 0,
        total: 0,
      };
      expect(BidCalculationFactory.createDefault()).toStrictEqual(expected);
    });
  });
});
