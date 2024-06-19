import { BidCalculation } from "./bid-calculation.interface";
import { VehicleType } from "../vehicle/vehicle-type.enum";

export class BidCalculationFactory {
  public static createDefault(): BidCalculation {
    return {
      vehiclePrice: 0,
      vehicleType: VehicleType.Common,
      basicFee: 0,
      specialFee: 0,
      associationFee: 0,
      storageFee: 0,
      total: 0,
    };
  }
}
