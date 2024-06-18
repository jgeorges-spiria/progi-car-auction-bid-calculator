import { VehicleType } from "../vehicle/vehicle-type.enum";

export interface BidCalculation {
    vehiclePrice: number,
    vehicleType: VehicleType,
    basicFee: number,
    specialFee: number,
    associationFee: number,
    storageFee: number,
    total: number
}