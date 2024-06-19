import { VehicleTypeDto } from "./vehicle-type.dto";

export interface BidCalculationResponseDto {
  vehiclePrice: number;
  vehicleType: VehicleTypeDto;
  basicFee: number;
  specialFee: number;
  associationFee: number;
  storageFee: number;
  total: number;
}
