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
        }
    }

    public static create(data: any): BidCalculation {
        return {
            vehiclePrice: data.vehiclePrice,
            vehicleType: data.vehicleType,
            basicFee: data.basicFee,
            specialFee: data.specialFee,
            associationFee: data.associationFee,
            storageFee: data.storageFee,
            total: data.total,
        }
    }

}

