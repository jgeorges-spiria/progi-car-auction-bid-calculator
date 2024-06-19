import { BidCalculation } from "../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";
import { BidCalculationResponseDto } from "./bid-calculation-response.dto";
import { VehicleTypeDto } from "./vehicle-type.dto";

export class CarAuctionBidApiDtoMapper {
  public static mapToBidCalculation(
    data: BidCalculationResponseDto,
  ): BidCalculation {
    return {
      vehiclePrice: data.vehiclePrice,
      vehicleType: this.mapToVehicleType(data.vehicleType),
      basicFee: data.basicFee,
      specialFee: data.specialFee,
      associationFee: data.associationFee,
      storageFee: data.storageFee,
      total: data.total,
    };
  }

  public static mapToVehicleType(vehicleType: VehicleTypeDto): VehicleType {
    if (vehicleType === "luxury") {
      return VehicleType.Luxury;
    }

    return VehicleType.Common;
  }
}
